import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:myfschoolse1915/vn/edu/fpt/model/notification_model.dart';

class NotificationController {
  final String baseUrl = '${ApiConfig.baseUrl}/api';

  Future<List<NotificationModel>> fetchNotifications(String token, {int page = 1, int pageSize = 20}) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/notification?page=$page&pageSize=$pageSize'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => NotificationModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<bool> markAsRead(String token, int notificationId) async {
    try {
      final response = await http.put(
        Uri.parse('$baseUrl/notification/$notificationId/read'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      return response.statusCode == 204;
    } catch (e) {
      return false;
    }
  }
}
