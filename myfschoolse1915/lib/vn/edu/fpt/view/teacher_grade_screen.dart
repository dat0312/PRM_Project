import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/grade_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/class_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/class_grade_detail_screen.dart';

class TeacherGradeScreen extends StatefulWidget {
  final LoginModel user;
  const TeacherGradeScreen({super.key, required this.user});

  @override
  State<TeacherGradeScreen> createState() => _TeacherGradeScreenState();
}

class _TeacherGradeScreenState extends State<TeacherGradeScreen> {
  final GradeController _controller = GradeController();
  List<ClassModel> _classes = [];
  bool _isLoading = true;
  String _selectedYear = '2025-2026';
  List<String> _years = [];
  ClassModel? _selectedClass;
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
    _fetchClasses();
  }

  Future<void> _fetchClasses() async {
    setState(() {
      _isLoading = true;
    });
    final classes = await _controller.fetchMyClasses(widget.user.token, academicYear: _selectedYear);
    setState(() {
      _classes = classes.where((c) => c.isHomeroom).toList();
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    if (_selectedClass != null) {
      return ClassGradeDetailScreen(
        token: widget.user.token,
        classId: _selectedClass!.id,
        className: _selectedClass!.name,
        isHomeroom: _selectedClass!.isHomeroom,
        academicYear: _selectedYear,
        onBackPressed: () {
          setState(() {
            _selectedClass = null;
          });
        },
      );
    }

    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        title: const Text("Lớp Đang Dạy"),
        backgroundColor: Colors.orange,
      ),
      body: _isLoading || _isLoadingYears
          ? const Center(child: CircularProgressIndicator())
          : Column(
              children: [
                _buildFilterRow(),
                Expanded(
                  child: _classes.isEmpty
                      ? const Center(child: Text("Bạn chưa có lịch dạy lớp nào"))
                      : ListView.builder(
                          padding: const EdgeInsets.all(16),
                          itemCount: _classes.length,
                          itemBuilder: (context, index) {
                            final cls = _classes[index];
                            return Card(
                              child: ListTile(
                                title: Row(
                                  children: [
                                    Text("Lớp ${cls.name}", style: const TextStyle(fontWeight: FontWeight.bold)),
                                    if (cls.isHomeroom) ...[
                                      const SizedBox(width: 8),
                                      Container(
                                        padding: const EdgeInsets.symmetric(horizontal: 6, vertical: 2),
                                        decoration: BoxDecoration(color: Colors.green, borderRadius: BorderRadius.circular(4)),
                                        child: const Text("GVCN", style: TextStyle(color: Colors.white, fontSize: 10, fontWeight: FontWeight.bold)),
                                      ),
                                    ]
                                  ],
                                ),
                                subtitle: Text("Khối ${cls.grade}"),
                                trailing: const Icon(Icons.arrow_forward_ios, size: 16),
                                onTap: () {
                                  setState(() {
                                    _selectedClass = cls;
                                  });
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
              });
              _fetchClasses();
            }
          },
        ),
      ),
    );
  }
}
