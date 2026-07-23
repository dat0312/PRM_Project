import 'package:flutter/material.dart';
import 'dart:typed_data';
import 'package:myfschoolse1915/vn/edu/fpt/controller/grade_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/grade_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/academic_rank_helper.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/student_grade_detail_screen.dart';

class ClassGradeDetailScreen extends StatefulWidget {
  final String token;
  final int classId;
  final String className;
  final bool isHomeroom;
  final String academicYear;
  final VoidCallback? onBackPressed;
  
  const ClassGradeDetailScreen({
    super.key,
    required this.token,
    required this.classId,
    required this.className,
    required this.isHomeroom,
    required this.academicYear,
    this.onBackPressed,
  });

  @override
  State<ClassGradeDetailScreen> createState() => _ClassGradeDetailScreenState();
}

class _ClassGradeDetailScreenState extends State<ClassGradeDetailScreen> {
  final GradeController _controller = GradeController();
  List<GradeModel> _allGrades = [];
  bool _isLoading = true;
  List<dynamic> _subjects = [];
  int? _selectedSubjectId;
  SubjectYearlyGrade? _selectedStudentGrade;
  String? _selectedStudentName;

  @override
  void initState() {
    super.initState();
    _fetchGrades();
    _fetchSubjects();
  }

  Future<void> _fetchSubjects() async {
    final subjects = await _controller.fetchSubjects(widget.token);
    setState(() {
      _subjects = subjects;
      if (_subjects.isNotEmpty) {
        _selectedSubjectId = _subjects[0]['id'];
      }
    });
  }

  Future<void> _fetchGrades() async {
    final grades = await _controller.fetchClassGrades(widget.token, widget.classId);
    setState(() {
      _allGrades = grades;
      _isLoading = false;
    });
  }

  Color _getRankColor(String rank) {
    if (rank.contains("Xuất sắc")) return Colors.purple;
    if (rank.contains("Giỏi")) return Colors.red;
    if (rank.contains("Khá")) return Colors.orange;
    if (rank.contains("Đạt")) return Colors.blue;
    return Colors.grey;
  }

  Widget _buildActionRow() {
    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Row(
        children: [
          Expanded(
            flex: 2,
            child: _subjects.isEmpty ? const SizedBox() : DropdownButton<int>(
              value: _selectedSubjectId,
              isExpanded: true,
              items: _subjects.map((s) => DropdownMenuItem<int>(
                value: s['id'],
                child: Text(s['name']),
              )).toList(),
              onChanged: (val) {
                setState(() { _selectedSubjectId = val; });
              },
            ),
          ),

        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    // Filter by academic year
    final filteredGrades = _allGrades.where((g) => g.academicYear == null || g.academicYear == widget.academicYear).toList();

    // Group by student
    Map<String, List<GradeModel>> studentGradesMap = {};
    for (var grade in filteredGrades) {
      final key = grade.studentName ?? "Unknown";
      if (!studentGradesMap.containsKey(key)) {
        studentGradesMap[key] = [];
      }
      studentGradesMap[key]!.add(grade);
    }

    if (_selectedStudentGrade != null && _selectedStudentName != null) {
      return StudentGradeDetailScreen(
        subjectGrade: _selectedStudentGrade!,
        studentName: _selectedStudentName!,
        onBackPressed: () {
          setState(() {
            _selectedStudentGrade = null;
            _selectedStudentName = null;
          });
        },
      );
    }

    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        leading: widget.onBackPressed != null
            ? IconButton(icon: const Icon(Icons.arrow_back), onPressed: widget.onBackPressed)
            : null,
        title: Text("Điểm lớp ${widget.className} - ${widget.academicYear}"),
        backgroundColor: Colors.orange,
      ),
      body: _isLoading
          ? const Center(child: CircularProgressIndicator())
          : Column(
              children: [
                _buildActionRow(),
                Expanded(
                  child: studentGradesMap.isEmpty
                      ? const Center(child: Text("Lớp chưa có dữ liệu điểm cho năm học này"))
                      : ListView.builder(
                          padding: const EdgeInsets.all(16),
                          itemCount: studentGradesMap.keys.length,
                          itemBuilder: (context, index) {
                    final studentName = studentGradesMap.keys.elementAt(index);
                    final rawGrades = studentGradesMap[studentName]!;
                    
                    // Group by subject and calculate yearly grades
                    final subjectGrades = AcademicRankHelper.groupGradesBySubject(rawGrades);
                    
                    String? rank;
                    if (widget.isHomeroom) {
                      rank = AcademicRankHelper.calculateRank(subjectGrades);
                    }
                    
                    // Filter by selected subject
                    final displayGrades = _selectedSubjectId != null
                        ? subjectGrades.where((sg) => sg.subjectId == _selectedSubjectId).toList()
                        : subjectGrades;
                    
                    final currentSubjectGrade = displayGrades.isNotEmpty ? displayGrades.first : null;

                    return Card(
                      margin: const EdgeInsets.only(bottom: 16),
                      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                      elevation: 2,
                      child: Padding(
                        padding: const EdgeInsets.all(12),
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Expanded(child: Text(studentName, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16))),
                                if (rank != null)
                                  Container(
                                    padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
                                    decoration: BoxDecoration(
                                      color: _getRankColor(rank).withOpacity(0.1),
                                      borderRadius: BorderRadius.circular(8),
                                    ),
                                    child: Text(
                                      rank,
                                      style: TextStyle(
                                        color: _getRankColor(rank),
                                        fontSize: 12,
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                  ),
                              ],
                            ),
                            if (currentSubjectGrade != null) ...[
                              const SizedBox(height: 8),
                              const Divider(),
                              ListTile(
                                contentPadding: EdgeInsets.zero,
                                title: Text(currentSubjectGrade.subjectName, style: const TextStyle(fontWeight: FontWeight.bold)),
                                trailing: Row(
                                  mainAxisSize: MainAxisSize.min,
                                  children: [
                                    Text(
                                      currentSubjectGrade.yearlyAverage?.toStringAsFixed(1) ?? "--",
                                      style: const TextStyle(fontWeight: FontWeight.bold, color: Colors.green, fontSize: 16),
                                    ),
                                    const SizedBox(width: 8),
                                    const Icon(Icons.arrow_forward_ios, size: 16, color: Colors.grey),
                                  ],
                                ),
                                onTap: () {
                                  setState(() {
                                    _selectedStudentGrade = currentSubjectGrade;
                                    _selectedStudentName = studentName;
                                  });
                                },
                              ),
                            ] else ...[
                              const Padding(
                                padding: EdgeInsets.only(top: 12),
                                child: Text("Chưa có điểm môn này", style: TextStyle(color: Colors.grey, fontStyle: FontStyle.italic)),
                              )
                            ]
                          ],
                        ),
                      ),
                    );
                  },
                ),
              ),
            ],
          ),
    );
  }
}
