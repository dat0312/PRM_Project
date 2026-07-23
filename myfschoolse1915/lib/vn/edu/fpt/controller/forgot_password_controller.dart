import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:myfschoolse1915/vn/edu/fpt/view/change_password_screen.dart';

class ForgotPasswordController {
  final String baseUrl = '${ApiConfig.baseUrl}/api/auth';

  Future<void> sendOtp(BuildContext context, String email, Function(String) onSuccess) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/forgot-password'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'email': email}),
      );

      final data = jsonDecode(response.body);
      if (response.statusCode == 200) {
        onSuccess(data['message'] ?? 'Thành công');
      } else {
        _showToast(context, data['message'] ?? 'Có lỗi xảy ra', Colors.redAccent);
      }
    } catch (e) {
      _showToast(context, 'Lỗi kết nối tới Server: $e', Colors.redAccent);
    }
  }

  Future<void> verifyOtp(BuildContext context, String email, String otp) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/verify-otp'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'email': email, 'otp': otp}),
      );

      if (response.statusCode == 200) {
        Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => ChangePasswordScreen(email: email, otp: otp)),
        );
      } else {
        final data = jsonDecode(response.body);
        _showToast(context, data['message'] ?? 'OTP không hợp lệ', Colors.redAccent);
      }
    } catch (e) {
      _showToast(context, 'Lỗi kết nối tới Server: $e', Colors.redAccent);
    }
  }

  Future<void> resetPassword(BuildContext context, String email, String otp, String newPassword) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/reset-password'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'email': email,
          'otp': otp,
          'newPassword': newPassword
        }),
      );

      if (response.statusCode == 200) {
        _showToast(context, 'Đổi mật khẩu thành công! Vui lòng đăng nhập lại.', Colors.green);
        Navigator.popUntil(context, (route) => route.isFirst);
      } else {
        final data = jsonDecode(response.body);
        _showToast(context, data['message'] ?? 'Có lỗi xảy ra', Colors.redAccent);
      }
    } catch (e) {
      _showToast(context, 'Lỗi kết nối tới Server: $e', Colors.redAccent);
    }
  }

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
