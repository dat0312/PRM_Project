import 'package:myfschoolse1915/vn/edu/fpt/model/request_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class RequestController {
  final String baseUrl = '${ApiConfig.baseUrl}/api';

  Future<List<RequestModel>> fetchUserRequests(int userId) async {
    final response = await http.get(Uri.parse('$baseUrl/AppRequest/user/$userId'));
    if (response.statusCode == 200) {
      List<dynamic> data = jsonDecode(response.body);
      return data.map((json) => RequestModel.fromJson(json)).toList();
    }
    throw Exception('Failed to load requests');
  }

  Future<bool> createRequest(String title, String content, int senderId, String receiverIds) async {
    final response = await http.post(
      Uri.parse('$baseUrl/AppRequest/compose'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({
        'title': title,
        'content': content,
        'senderId': senderId,
        'receiverIds': receiverIds,
        'category': 'Tin nhắn',
      }),
    );
    return response.statusCode == 200;
  }

  Future<List<Map<String, dynamic>>> searchEmails(String query) async {
    if (query.length < 2) return [];
    final response = await http.get(Uri.parse('$baseUrl/User/search-email?q=$query'));
    if (response.statusCode == 200) {
      List<dynamic> data = jsonDecode(response.body);
      return data.map((e) => e as Map<String, dynamic>).toList();
    }
    return [];
  }
}
