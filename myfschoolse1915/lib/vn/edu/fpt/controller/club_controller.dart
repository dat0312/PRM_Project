import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:myfschoolse1915/vn/edu/fpt/model/club_model.dart';

class ClubController {
  final String baseUrl = '${ApiConfig.baseUrl}/api';

  Future<List<ClubModel>> fetchClubs() async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/club'));
      if (response.statusCode == 200) {
        List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => ClubModel.fromJson(json)).toList();
      } else {
        throw Exception('Failed to load clubs');
      }
    } catch (e) {
      print('Error fetching clubs: $e');
      throw e;
    }
  }

  Future<ClubStatsModel> fetchClubStats() async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/club/stats'));
      if (response.statusCode == 200) {
        return ClubStatsModel.fromJson(jsonDecode(response.body));
      } else {
        throw Exception('Failed to load club stats');
      }
    } catch (e) {
      print('Error fetching club stats: $e');
      throw e;
    }
  }

  Future<bool> createClub(String name, String type, String status, String description, int? presidentId) async {
    final response = await http.post(
      Uri.parse('$baseUrl/club/add'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({
        'name': name,
        'type': type,
        'status': status,
        'description': description,
        'presidentId': presidentId
      }),
    );
    return response.statusCode == 200;
  }

  Future<bool> updateClub(int id, String name, String type, String status, String description, int? presidentId) async {
    final response = await http.put(
      Uri.parse('$baseUrl/club/update/$id'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({
        'name': name,
        'type': type,
        'status': status,
        'description': description,
        'presidentId': presidentId
      }),
    );
    return response.statusCode == 200;
  }

  Future<bool> deleteClub(int id) async {
    final response = await http.delete(Uri.parse('$baseUrl/club/delete/$id'));
    return response.statusCode == 200;
  }

  Future<List<dynamic>> fetchClubMembers(int id) async {
    final response = await http.get(Uri.parse('$baseUrl/club/$id/members'));
    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    }
    throw Exception('Failed to load members');
  }

  Future<bool> addClubMember(int clubId, int userId) async {
    final response = await http.post(
      Uri.parse('$baseUrl/club/$clubId/add-member'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({'userId': userId}),
    );
    return response.statusCode == 200;
  }

  Future<bool> removeClubMember(int clubId, int userId) async {
    final response = await http.delete(Uri.parse('$baseUrl/club/$clubId/remove-member/$userId'));
    return response.statusCode == 200;
  }

  Future<bool> joinRequest(int clubId, int userId, String reason) async {
    final response = await http.post(
      Uri.parse('$baseUrl/club/$clubId/join-request'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({'userId': userId, 'reason': reason}),
    );
    if (response.statusCode != 200) {
      final msg = jsonDecode(response.body)['message'];
      throw Exception(msg ?? 'Gửi yêu cầu thất bại');
    }
    return true;
  }

  Future<List<dynamic>> fetchPendingRequests(int clubId) async {
    final response = await http.get(Uri.parse('$baseUrl/club/$clubId/pending-requests'));
    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    }
    throw Exception('Failed to load requests');
  }

  Future<bool> transferPresident(int clubId, int currentId, int newId) async {
    final response = await http.post(
      Uri.parse('$baseUrl/club/$clubId/transfer-president'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({'currentPresidentId': currentId, 'newPresidentId': newId}),
    );
    if (response.statusCode != 200) {
      final msg = jsonDecode(response.body)['message'];
      throw Exception(msg ?? 'Chuyển quyền thất bại');
    }
    return true;
  }

  Future<bool> approveRequest(int requestId) async {
    final response = await http.post(Uri.parse('$baseUrl/AppRequest/$requestId/approve'));
    if (response.statusCode != 200) {
      throw Exception('Duyệt đơn thất bại');
    }
    return true;
  }

  Future<bool> rejectRequest(int requestId) async {
    final response = await http.post(Uri.parse('$baseUrl/AppRequest/$requestId/reject'));
    if (response.statusCode != 200) {
      throw Exception('Từ chối đơn thất bại');
    }
    return true;
  }
}
