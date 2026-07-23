import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/grade_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/grade_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/academic_rank_helper.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/student_grade_detail_screen.dart';

class GradeScreen extends StatefulWidget {
  final LoginModel user;
  const GradeScreen({super.key, required this.user});

  @override
  State<GradeScreen> createState() => _GradeScreenState();
}

class _GradeScreenState extends State<GradeScreen> {
  final GradeController _controller = GradeController();
  List<GradeModel> _allGrades = [];
  List<SubjectYearlyGrade> _subjectGrades = [];
  String _academicRank = "Chưa xếp loại";
  bool _isLoading = true;
  
  String _selectedYear = '2025-2026';
  List<String> _years = ['2025-2026', '2024-2025', '2023-2024'];
  bool _isLoadingYears = true;

  @override
  void initState() {
    super.initState();
    _initData();
  }

  Future<void> _initData() async {
    final years = await _controller.fetchAcademicYears();
    setState(() {
      if (years.isNotEmpty) {
        _years = years;
        _selectedYear = years.first;
      }
      _isLoadingYears = false;
    });
    _fetchGrades();
  }

  Future<void> _fetchGrades() async {
    final grades = await _controller.fetchMyGrades(widget.user.token);
    setState(() {
      _allGrades = grades;
      _isLoading = false;
      _filterGrades();
    });
  }
  
  void _filterGrades() {
    setState(() {
      var yearGrades = _allGrades.where((g) => g.academicYear == null || g.academicYear == _selectedYear).toList();
      _subjectGrades = AcademicRankHelper.groupGradesBySubject(yearGrades);
      _academicRank = AcademicRankHelper.calculateRank(_subjectGrades);
    });
  }

  Color _getRankColor(String rank) {
    if (rank.contains("Xuất sắc")) return Colors.purple;
    if (rank.contains("Giỏi")) return Colors.red;
    if (rank.contains("Khá")) return Colors.orange;
    if (rank.contains("Đạt")) return Colors.blue;
    return Colors.grey;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        elevation: 0,
        centerTitle: true,
        title: const Text(
          'Bảng điểm cá nhân',
          style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 20),
        ),
        leading: TextButton.icon(
          onPressed: () => Navigator.pop(context),
          icon: const Icon(Icons.chevron_left, color: Colors.white),
          label: const Text('Home', style: TextStyle(color: Colors.white, fontSize: 16)),
        ),
        leadingWidth: 100,
        shape: const RoundedRectangleBorder(
          borderRadius: BorderRadius.vertical(bottom: Radius.circular(24)),
        ),
      ),
      body: _isLoading || _isLoadingYears
          ? const Center(child: CircularProgressIndicator())
          : Column(
              children: [
                _buildFilterRow(),
                _buildRankBanner(),
                Expanded(
                  child: _subjectGrades.isEmpty
                      ? const Center(child: Text("Không có dữ liệu điểm cho năm học này."))
                      : ListView.builder(
                          padding: const EdgeInsets.all(16),
                          itemCount: _subjectGrades.length,
                          itemBuilder: (context, index) {
                            final subjectGrade = _subjectGrades[index];
                            return Card(
                              margin: const EdgeInsets.only(bottom: 12),
                              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                              elevation: 2,
                              child: ListTile(
                                contentPadding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                                title: Text(
                                  subjectGrade.subjectName,
                                  style: const TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
                                ),
                                trailing: Row(
                                  mainAxisSize: MainAxisSize.min,
                                  children: [
                                    Text(
                                      subjectGrade.yearlyAverage?.toStringAsFixed(1) ?? "--",
                                      style: const TextStyle(
                                        fontSize: 20,
                                        fontWeight: FontWeight.bold,
                                        color: Colors.green,
                                      ),
                                    ),
                                    const SizedBox(width: 8),
                                    const Icon(Icons.arrow_forward_ios, size: 16, color: Colors.grey),
                                  ],
                                ),
                                onTap: () {
                                  Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                      builder: (context) => StudentGradeDetailScreen(subjectGrade: subjectGrade, studentName: widget.user.fullName),
                                    ),
                                  );
                                },
                              ),
                            );
                          },
                        ),
                ),
              ],
            ),
    );
  }

  Widget _buildRankBanner() {
    return Container(
      margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        gradient: LinearGradient(
          colors: [_getRankColor(_academicRank).withOpacity(0.8), _getRankColor(_academicRank)],
        ),
        borderRadius: BorderRadius.circular(16),
        boxShadow: [
          BoxShadow(
            color: _getRankColor(_academicRank).withOpacity(0.3),
            blurRadius: 8,
            offset: const Offset(0, 4),
          )
        ],
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const Icon(Icons.stars, color: Colors.white, size: 32),
          const SizedBox(width: 12),
          Text(
            _academicRank,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 24,
              fontWeight: FontWeight.bold,
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildFilterRow() {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 4),
      margin: const EdgeInsets.only(top: 16, left: 16, right: 16, bottom: 8),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(12),
        boxShadow: [
          BoxShadow(
            color: Colors.black.withOpacity(0.05),
            blurRadius: 10,
            offset: const Offset(0, 4),
          )
        ],
      ),
      child: DropdownButtonHideUnderline(
        child: DropdownButton<String>(
          value: _selectedYear,
          isExpanded: true,
          icon: const Icon(Icons.keyboard_arrow_down, color: Colors.orange),
          items: _years.map((year) {
            return DropdownMenuItem(
              value: year,
              child: Text("Năm học $year", style: const TextStyle(fontWeight: FontWeight.w600, fontSize: 16)),
            );
          }).toList(),
          onChanged: (val) {
            if (val != null) {
              setState(() {
                _selectedYear = val;
                _filterGrades();
              });
            }
          },
        ),
      ),
    );
  }
}
