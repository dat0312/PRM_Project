import 'package:flutter/material.dart';

class HelpScreen extends StatelessWidget {
  const HelpScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        elevation: 0,
        centerTitle: true,
        title: const Text(
          'Trung tâm trợ giúp',
          style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18),
        ),
        leading: TextButton.icon(
          onPressed: () => Navigator.pop(context),
          icon: const Icon(Icons.chevron_left, color: Colors.white),
          label: const Text('Home', style: TextStyle(color: Colors.white, fontSize: 16)),
        ),
        leadingWidth: 100,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const Text(
              "Chúng tôi có thể giúp gì cho bạn?",
              style: TextStyle(fontSize: 22, fontWeight: FontWeight.bold, color: Color(0xFF1A237E)),
            ),
            const SizedBox(height: 24),
            
            // Hỗ trợ trực tiếp
            _buildSupportSection(),
            
            const SizedBox(height: 32),
            const Text(
              "Câu hỏi thường gặp",
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold, color: Color(0xFF1A237E)),
            ),
            const SizedBox(height: 16),
            
            // Danh sách FAQ
            _buildFaqItem("Làm sao để đăng ký đơn xin nghỉ học?"),
            _buildFaqItem("Tôi có thể xem lịch thi ở đâu?"),
            _buildFaqItem("Làm thế nào để đổi mật khẩu ứng dụng?"),
            _buildFaqItem("Quy trình phúc khảo bài thi như thế nào?"),
          ],
        ),
      ),
      bottomNavigationBar: Container(
        decoration: BoxDecoration(
          color: Colors.white,
          boxShadow: [
            BoxShadow(color: Colors.black.withOpacity(0.05), blurRadius: 10, offset: const Offset(0, -5))
          ],
        ),
        child: BottomNavigationBar(
          elevation: 0,
          backgroundColor: Colors.transparent,
          selectedItemColor: Colors.orange,
          unselectedItemColor: Colors.grey,
          currentIndex: 1,
          onTap: (index) {
            Navigator.pop(context);
          },
          items: const [
            BottomNavigationBarItem(
              icon: Icon(Icons.notifications_none_rounded), 
              activeIcon: Icon(Icons.notifications_rounded),
              label: 'Thông báo'
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.home_outlined), 
              activeIcon: Icon(Icons.home_rounded),
              label: 'Trang chủ'
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.person_outline_rounded), 
              activeIcon: Icon(Icons.person_rounded),
              label: 'Cá nhân'
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildSupportSection() {
    return Column(
      children: [
        _buildContactCard(
          icon: Icons.headset_mic_rounded,
          title: "Tổng đài hỗ trợ",
          subtitle: "1900 1234 (Hỗ trợ 24/7)",
          color: Colors.blue,
        ),
        const SizedBox(height: 12),
        _buildContactCard(
          icon: Icons.mail_rounded,
          title: "Email liên hệ",
          subtitle: "support@fpt.edu.vn",
          color: Colors.red,
        ),
        const SizedBox(height: 12),
        _buildContactCard(
          icon: Icons.chat_bubble_rounded,
          title: "Chat trực tuyến",
          subtitle: "Phản hồi ngay lập tức",
          color: Colors.green,
        ),
      ],
    );
  }

  Widget _buildContactCard({required IconData icon, required String title, required String subtitle, required Color color}) {
    return Container(
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(16),
        boxShadow: [BoxShadow(color: Colors.black.withOpacity(0.03), blurRadius: 10, offset: const Offset(0, 4))],
      ),
      child: ListTile(
        contentPadding: const EdgeInsets.symmetric(horizontal: 20, vertical: 8),
        leading: Container(
          padding: const EdgeInsets.all(10),
          decoration: BoxDecoration(
            color: color.withOpacity(0.1),
            shape: BoxShape.circle,
          ),
          child: Icon(icon, color: color),
        ),
        title: Text(title, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 15)),
        subtitle: Text(subtitle, style: TextStyle(color: Colors.grey.shade600, fontSize: 13)),
        trailing: const Icon(Icons.arrow_forward_ios_rounded, size: 14, color: Colors.grey),
        onTap: () {},
      ),
    );
  }

  Widget _buildFaqItem(String question) {
    return Container(
      margin: const EdgeInsets.only(bottom: 12),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(12),
      ),
      child: ExpansionTile(
        title: Text(question, style: const TextStyle(fontSize: 14, fontWeight: FontWeight.w500)),
        shape: const RoundedRectangleBorder(side: BorderSide.none),
        children: const [
          Padding(
            padding: EdgeInsets.fromLTRB(16, 0, 16, 16),
            child: Text(
              "Bạn có thể thực hiện việc này bằng cách vào mục tương ứng trong menu chính. Nếu gặp khó khăn, vui lòng liên hệ tổng đài để được hướng dẫn chi tiết.",
              style: TextStyle(color: Colors.grey, fontSize: 13, height: 1.4),
            ),
          ),
        ],
      ),
    );
  }
}
