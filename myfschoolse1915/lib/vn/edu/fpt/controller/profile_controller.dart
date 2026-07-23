import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';

class ProfileController {
  final String baseUrl = '${ApiConfig.baseUrl}/api/Profile/me';

  Future<LoginModel?> fetchMyProfile(BuildContext context, String token) async {
    try {
      final response = await http.get(
        Uri.parse(baseUrl),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );

      if (response.statusCode == 200) {
        final data = jsonDecode(response.body);
        return LoginModel(
          id: data['id'] ?? 0,
          fullName: data['fullName'] ?? '',
          className: data['className'] ?? '',
          studentId: data['studentId'] ?? '',
          phoneNumber: data['phoneNumber'] ?? '',
          email: data['email'] ?? '',
          token: token,
          avatarUrl: data['avatarUrl'] ?? '',
          roles: (data['roles'] as List<dynamic>?)?.map((e) => e.toString()).toList() ?? [],
        );
      } else {
        _showToast(context, 'Lấy thông tin thất bại (${response.statusCode})', Colors.red);
        return null;
      }
    } catch (e) {
      _showToast(context, 'Lỗi kết nối: $e', Colors.red);
      return null;
    }
  }

  Future<bool> updateMyProfile(BuildContext context, String token, String email, String phone) async {
    try {
      final response = await http.put(
        Uri.parse(baseUrl),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
        body: jsonEncode({
          'email': email,
          'phoneNumber': phone,
        }),
      );

      final data = jsonDecode(response.body);
      if (response.statusCode == 200) {
        _showToast(context, 'Cập nhật hồ sơ thành công!', Colors.green);
        return true;
      } else {
        _showToast(context, data['message'] ?? 'Lỗi cập nhật', Colors.red);
        return false;
      }
    } catch (e) {
      _showToast(context, 'Lỗi kết nối: $e', Colors.red);
      return false;
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
