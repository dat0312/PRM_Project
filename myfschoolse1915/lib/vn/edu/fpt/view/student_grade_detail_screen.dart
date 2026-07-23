import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/grade_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/academic_rank_helper.dart';

class StudentGradeDetailScreen extends StatelessWidget {
  final SubjectYearlyGrade subjectGrade;
  final String studentName;
  final VoidCallback? onBackPressed;

  const StudentGradeDetailScreen({
    super.key, 
    required this.subjectGrade,
    required this.studentName,
    this.onBackPressed,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF4F7FC),
      appBar: AppBar(
        leading: onBackPressed != null
            ? IconButton(icon: const Icon(Icons.arrow_back_ios, color: Colors.white, size: 20), onPressed: onBackPressed)
            : null,
        title: Text("Bảng điểm chi tiết - $studentName", style: const TextStyle(fontWeight: FontWeight.bold, color: Colors.white, fontSize: 18)),
        backgroundColor: const Color(0xFF2B3674),
        elevation: 0,
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 20),
        child: Column(
          children: [
            _buildYearlySummaryCard(),
            const SizedBox(height: 24),
            _buildSemesterCard("Học kỳ 1", subjectGrade.semester1 ?? GradeModel(id: 0, subjectName: subjectGrade.subjectName, semester: 1)),
            const SizedBox(height: 24),
            _buildSemesterCard("Học kỳ 2", subjectGrade.semester2 ?? GradeModel(id: 0, subjectName: subjectGrade.subjectName, semester: 2)),
            const SizedBox(height: 40),
          ],
        ),
      ),
    );
  }

  Widget _buildYearlySummaryCard() {
    return Container(
      width: double.infinity,
      decoration: BoxDecoration(
        gradient: const LinearGradient(colors: [Color(0xFF4318FF), Color(0xFF39B8FF)]),
        borderRadius: BorderRadius.circular(16),
        boxShadow: [
          BoxShadow(color: const Color(0xFF4318FF).withOpacity(0.3), blurRadius: 12, offset: const Offset(0, 6))
        ]
      ),
      padding: const EdgeInsets.all(24),
      child: Column(
        children: [
          Text(
            subjectGrade.subjectName.toUpperCase(),
            style: const TextStyle(fontSize: 16, fontWeight: FontWeight.w600, color: Colors.white70, letterSpacing: 1.2),
          ),
          const SizedBox(height: 8),
          const Text(
            "ĐIỂM TRUNG BÌNH CẢ NĂM",
            style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold, color: Colors.white),
          ),
          const SizedBox(height: 12),
          Text(
            subjectGrade.yearlyAverage?.toStringAsFixed(1) ?? '--',
            style: const TextStyle(fontSize: 48, fontWeight: FontWeight.w800, color: Colors.white),
          ),
        ],
      ),
    );
  }

  Widget _buildSemesterCard(String title, GradeModel grade) {
    return Container(
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(16),
        boxShadow: [
          BoxShadow(color: Colors.black.withOpacity(0.04), blurRadius: 10, offset: const Offset(0, 4))
        ]
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 16),
            decoration: const BoxDecoration(
              color: Color(0xFFF8F9FA),
              borderRadius: BorderRadius.only(topLeft: Radius.circular(16), topRight: Radius.circular(16)),
            ),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  title,
                  style: const TextStyle(fontSize: 18, fontWeight: FontWeight.w800, color: Color(0xFF2B3674)),
                ),
                Container(
                  padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 6),
                  decoration: BoxDecoration(color: const Color(0xFFE9EDF7), borderRadius: BorderRadius.circular(20)),
                  child: Text(
                    "ĐTB: ${grade.averageScore?.toStringAsFixed(1) ?? '--'}",
                    style: const TextStyle(fontSize: 14, fontWeight: FontWeight.w700, color: Color(0xFF4318FF)),
                  ),
                ),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(20),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                _buildSectionTitle("Đánh giá thường xuyên (Hệ số 1)", Icons.edit_note, Colors.blue),
                const SizedBox(height: 12),
                _buildScoreRow("Kiểm tra Miệng 1", grade.attendanceScore),
                _buildScoreRow("Kiểm tra Miệng 2", grade.oralScore1),
                _buildScoreRow("Kiểm tra Miệng 3", grade.oralScore2),
                _buildScoreRow("Kiểm tra 15 phút 1", grade.fifteenMinScore1),
                _buildScoreRow("Kiểm tra 15 phút 2", grade.fifteenMinScore2),
                
                const Padding(padding: EdgeInsets.symmetric(vertical: 16), child: Divider(color: Color(0xFFE2E8F0))),
                
                _buildSectionTitle("Đánh giá giữa kỳ (Hệ số 2)", Icons.assessment, Colors.orange),
                const SizedBox(height: 12),
                _buildScoreRow("Kiểm tra giữa kỳ", grade.midtermScore),

                const Padding(padding: EdgeInsets.symmetric(vertical: 16), child: Divider(color: Color(0xFFE2E8F0))),
                
                _buildSectionTitle("Đánh giá cuối kỳ (Hệ số 3)", Icons.flag, Colors.red),
                const SizedBox(height: 12),
                _buildScoreRow("Kiểm tra cuối kỳ", grade.finalScore),
              ],
            ),
          )
        ],
      ),
    );
  }

  Widget _buildSectionTitle(String title, IconData icon, Color color) {
    return Row(
      children: [
        Icon(icon, size: 18, color: color),
        const SizedBox(width: 8),
        Text(title, style: TextStyle(fontWeight: FontWeight.bold, color: color, fontSize: 14)),
      ],
    );
  }

  Widget _buildScoreRow(String label, double? score) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(label, style: const TextStyle(color: Color(0xFF707EAE), fontSize: 14)),
          Text(score?.toString() ?? '--', style: const TextStyle(fontWeight: FontWeight.w700, color: Color(0xFF2B3674), fontSize: 15)),
        ],
      ),
    );
  }
}
