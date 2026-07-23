import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/login.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/profile_controller.dart';

class ProfileScreen extends StatefulWidget {
  final LoginModel user;
  const ProfileScreen({super.key, required this.user});

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  late LoginModel _currentUser;
  final ProfileController _controller = ProfileController();
  bool _isLoading = false;

  @override
  void initState() {
    super.initState();
    _currentUser = widget.user;
    // Tự động fetch profile mới nhất khi mở tab Profile
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _fetchProfile();
    });
  }

  Future<void> _fetchProfile() async {
    setState(() => _isLoading = true);
    final updatedUser = await _controller.fetchMyProfile(context, _currentUser.token);
    if (updatedUser != null) {
      setState(() {
        _currentUser = updatedUser;
      });
    }
    setState(() => _isLoading = false);
  }

  void _handleLogout(BuildContext context) {
    Navigator.pushAndRemoveUntil(
      context,
      MaterialPageRoute(builder: (context) => const LoginScreen()),
      (route) => false,
    );
  }

  void _showEditDialog() {
    final TextEditingController emailCtrl = TextEditingController(text: _currentUser.email);
    final TextEditingController phoneCtrl = TextEditingController(text: _currentUser.phoneNumber);

    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: const Text('Cập nhật thông tin', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18)),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextField(
                controller: emailCtrl,
                decoration: const InputDecoration(labelText: 'Email', prefixIcon: Icon(Icons.email)),
              ),
              const SizedBox(height: 12),
              TextField(
                controller: phoneCtrl,
                keyboardType: TextInputType.phone,
                decoration: const InputDecoration(labelText: 'Số điện thoại', prefixIcon: Icon(Icons.phone)),
              ),
            ],
          ),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Hủy', style: TextStyle(color: Colors.grey)),
            ),
            ElevatedButton(
              style: ElevatedButton.styleFrom(backgroundColor: Colors.orange),
              onPressed: () async {
                Navigator.pop(context); // Đóng dialog
                setState(() => _isLoading = true);
                bool success = await _controller.updateMyProfile(context, _currentUser.token, emailCtrl.text, phoneCtrl.text);
                if (success) {
                  _fetchProfile(); // Tải lại data mới
                } else {
                  setState(() => _isLoading = false);
                }
              },
              child: const Text('Lưu thay đổi', style: TextStyle(color: Colors.white)),
            ),
          ],
        );
      },
    );
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
          'Thông tin cá nhân',
          style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18),
        ),
        automaticallyImplyLeading: false,
        actions: [
          IconButton(
            icon: const Icon(Icons.edit, color: Colors.white),
            onPressed: _showEditDialog,
            tooltip: 'Chỉnh sửa thông tin',
          )
        ],
      ),
      body: _isLoading 
          ? const Center(child: CircularProgressIndicator(color: Colors.orange))
          : RefreshIndicator(
              onRefresh: _fetchProfile,
              color: Colors.orange,
              child: SingleChildScrollView(
                physics: const AlwaysScrollableScrollPhysics(),
                child: Column(
                  children: [
                    const SizedBox(height: 20),
                    Center(
                      child: Stack(
                        children: [
                          Container(
                            padding: const EdgeInsets.all(4),
                            decoration: const BoxDecoration(color: Colors.white, shape: BoxShape.circle),
                            child: CircleAvatar(
                              radius: 60,
                              backgroundColor: const Color(0xFFEEEEEE),
                              backgroundImage: _currentUser.avatarUrl.isNotEmpty 
                                  ? NetworkImage(_currentUser.avatarUrl) 
                                  : null,
                              child: _currentUser.avatarUrl.isEmpty 
                                  ? const Icon(Icons.person, size: 80, color: Colors.grey)
                                  : null,
                            ),
                          ),
                          // Removed camera icon for admin
                        ],
                      ),
                    ),
                    const SizedBox(height: 16),
                    Text(
                      _currentUser.fullName,
                      style: const TextStyle(fontSize: 22, fontWeight: FontWeight.bold, color: Color(0xFF1A237E)),
                    ),
                    Text(
                      _currentUser.roles.contains('Teacher') 
                          ? (_currentUser.studentId.isNotEmpty ? _currentUser.studentId : 'Chưa cập nhật mã')
                          : "Mã sinh viên: ${_currentUser.studentId.isNotEmpty ? _currentUser.studentId : 'Chưa cập nhật'}",
                      style: const TextStyle(color: Colors.grey, fontSize: 14),
                    ),
                    const SizedBox(height: 30),
                    if (!_currentUser.roles.contains('Teacher'))
                      _buildProfileItem(Icons.school_outlined, "Lớp học", _currentUser.className.isNotEmpty ? _currentUser.className : "Chưa cập nhật"),
                    _buildProfileItem(Icons.phone_android_rounded, "Số điện thoại", _currentUser.phoneNumber),
                    _buildProfileItem(Icons.email_outlined, "Email", _currentUser.email.isNotEmpty ? _currentUser.email : "Chưa cập nhật"),
                    _buildProfileItem(Icons.location_on_outlined, "Cơ sở", "FPT School Hà Nội"),
                    const SizedBox(height: 30),
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 24),
                      child: ElevatedButton.icon(
                        onPressed: () => _handleLogout(context),
                        icon: const Icon(Icons.logout_rounded),
                        label: const Text("Đăng xuất tài khoản"),
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.red.shade50,
                          foregroundColor: Colors.red,
                          elevation: 0,
                          minimumSize: const Size(double.infinity, 50),
                          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                        ),
                      ),
                    ),
                    const SizedBox(height: 40),
                  ],
                ),
              ),
            ),
    );
  }

  Widget _buildProfileItem(IconData icon, String label, String value) {
    return Container(
      margin: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(16),
        boxShadow: [
          BoxShadow(
            color: Colors.black.withOpacity(0.03),
            blurRadius: 10,
            offset: const Offset(0, 4),
          )
        ],
      ),
      child: Row(
        children: [
          Icon(icon, color: Colors.orange, size: 24),
          const SizedBox(width: 16),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(label, style: const TextStyle(color: Colors.grey, fontSize: 12)),
                const SizedBox(height: 2),
                Text(value, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 15)),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
