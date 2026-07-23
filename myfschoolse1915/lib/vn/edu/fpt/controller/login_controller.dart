import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/home_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/schedule_screen.dart';

class LoginController {
  // 1. Tạo sẵn một tài khoản có dữ liệu "cứng"
  final LoginModel _mockUser = LoginModel(
    id: 1,
    fullName: "Phan Thành Đạt",
    className: "SE1915",
    studentId: "HE181454",
    phoneNumber: "0352578129",
    email: "datpt@example.com",
    token: "mock_token",
    avatarUrl: "",
    roles: ["Student"],
  );

  // 2. Hàm xử lý logic Đăng nhập (Gọi API thực)
  Future<void> handleLogin({
    required BuildContext context,
    required String phone,
    required String password,
  }) async {
    if (phone.trim().isEmpty || password.trim().isEmpty) {
      _showToast(context, 'Vui lòng nhập đầy đủ số điện thoại và mật khẩu!', Colors.redAccent);
      return;
    }

    try {
      final response = await http.post(
        Uri.parse('${ApiConfig.baseUrl}/api/auth/login'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'PhoneNumber': phone,
          'password': password
        }),
      );

      if (response.statusCode == 200) {
        final data = jsonDecode(response.body);
        
        // Cập nhật lại LoginModel với dữ liệu từ backend
        final loggedInUser = LoginModel.fromJson(data);

        if (loggedInUser.roles.contains('Admin') || loggedInUser.roles.contains('Teacher')) {
          _showToast(context, 'Tài khoản Admin và Giáo viên vui lòng sử dụng Website!', Colors.redAccent);
          return;
        }

        Navigator.pushReplacement(
          context,
          MaterialPageRoute(
            builder: (context) {
              if (MediaQuery.of(context).size.width > 800) {
                return ScheduleScreen(user: loggedInUser);
              }
              return HomeScreen(user: loggedInUser);
            },
          ),
        );
      } else {
        _showToast(context, 'Sai số điện thoại hoặc mật khẩu (mã lỗi: ${response.statusCode})', Colors.redAccent);
      }
    } catch (e) {
      _showToast(context, 'Lỗi kết nối tới Server: $e', Colors.redAccent);
    }
  }

  // Hàm hiển thị thông báo SnackBar
  void _showToast(BuildContext context, String message, Color bgColor) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text(message),
        backgroundColor: bgColor,
        duration: const Duration(seconds: 2),
      ),
    );
  }
}
