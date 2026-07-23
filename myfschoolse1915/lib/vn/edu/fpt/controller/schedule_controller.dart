import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:myfschoolse1915/vn/edu/fpt/model/schedule_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/schedule_request_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/subject_model.dart';

class ClassModel {
  final int id;
  final String name;
  final int? grade;
  final String? cohort;
  ClassModel({required this.id, required this.name, this.grade, this.cohort});
  factory ClassModel.fromJson(Map<String, dynamic> json) => ClassModel(
    id: json['id'], 
    name: json['name'],
    grade: json['grade'],
    cohort: json['cohort'],
  );
}

class RoomModel {
  final int id;
  final String name;
  RoomModel({required this.id, required this.name});
  factory RoomModel.fromJson(Map<String, dynamic> json) => RoomModel(id: json['id'], name: json['name']);
}

class TeacherModel {
  final int id;
  final String fullName;
  TeacherModel({required this.id, required this.fullName});
  factory TeacherModel.fromJson(Map<String, dynamic> json) => TeacherModel(id: json['id'], fullName: json['fullName']);
}

class ScheduleController {
  final String baseUrl = '${ApiConfig.baseUrl}/api';

  Future<List<ScheduleModel>> fetchSchedules(String token, DateTime? startDate, DateTime? endDate, {int? roomId, int? teacherId, int? classId}) async {
    try {
      String url = '$baseUrl/schedule?';
      if (startDate != null) url += 'startDate=${startDate.toIso8601String()}&';
      if (endDate != null) url += 'endDate=${endDate.toIso8601String()}&';
      if (roomId != null) url += 'roomId=$roomId&';
      if (teacherId != null) url += 'teacherId=$teacherId&';
      if (classId != null) url += 'classId=$classId&';

      final response = await http.get(
        Uri.parse(url),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => ScheduleModel.fromJson(json)).toList();
      } else {
        return [];
      }
    } catch (e) {
      return [];
    }
  }

  Future<String?> createRequest(String token, Map<String, dynamic> reqData) async {
    try {
      final response = await http.post(
        Uri.parse('${ApiConfig.baseUrl}/api/AppRequest/compose'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
        body: jsonEncode(reqData),
      );
      if (response.statusCode == 200) {
        return null;
      }
      return 'Lỗi khi gửi đơn: ${response.statusCode}';
    } catch (e) {
      return 'Lỗi kết nối: $e';
    }
  }

  Future<List<ScheduleRequestModel>> fetchRequests(String token) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/schedule/requests'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => ScheduleRequestModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<List<int>> fetchOccupiedSlots(String token, DateTime date, int classId) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/schedule/occupied-slots?date=${date.toIso8601String()}&classId=$classId'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.cast<int>();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<List<Map<String, dynamic>>> fetchOccupiedPatterns(String token, int classId) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/schedule/class/$classId/occupied-patterns'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.cast<Map<String, dynamic>>();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<bool> submitScheduleRequest(String token, ScheduleRequestModel request) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/schedule/requests'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
        body: jsonEncode(request.toJson()),
      );
      return response.statusCode == 200;
    } catch (e) {
      return false;
    }
  }

  Future<bool> updateRequestStatus(String token, int requestId, String status, {int? substituteTeacherId}) async {
    try {
      final response = await http.put(
        Uri.parse('$baseUrl/schedule/requests/$requestId/status'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
        body: jsonEncode({
          'status': status,
          if (substituteTeacherId != null) 'substituteTeacherId': substituteTeacherId,
        }),
      );
      return response.statusCode == 200;
    } catch (e) {
      return false;
    }
  }

  Future<List<Map<String, dynamic>>> fetchAvailableSubstituteTeachers(String token, int scheduleId) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/schedule/substitutes/$scheduleId'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        return List<Map<String, dynamic>>.from(jsonDecode(response.body));
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<List<ClassModel>> fetchClasses(String token, {String? academicYear}) async {
    try {
      String url = '$baseUrl/class';
      if (academicYear != null) {
        url += '?academicYear=$academicYear';
      }
      final response = await http.get(Uri.parse(url), headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => ClassModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) { return []; }
  }

  Future<List<RoomModel>> fetchRooms(String token) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/room'), headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => RoomModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) { return []; }
  }

  Future<List<TeacherModel>> fetchTeachers(String token) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/user/teachers'), headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => TeacherModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) { return []; }
  }

  Future<List<SubjectModel>> fetchSubjects(String token, int grade, String group) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/subject?grade=$grade&group=$group'), headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => SubjectModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) { return []; }
  }

  Future<List<TeacherModel>> fetchTeachersBySubject(String token, int subjectId) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/subject/$subjectId/teachers'), headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => TeacherModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) { return []; }
  }

  Future<List<TeacherModel>> fetchSubstituteTeachers(String token, int scheduleId) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/schedule/substitutes/$scheduleId'), headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => TeacherModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) { return []; }
  }

  Future<String?> createBulkSchedule(String token, Map<String, dynamic> requestBody) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/schedule/bulk'),
        headers: {'Content-Type': 'application/json', 'Authorization': 'Bearer $token'},
        body: jsonEncode(requestBody),
      );
      if (response.statusCode == 200) return null; // Success
      final Map<String, dynamic> error = jsonDecode(response.body);
      return error['message'] ?? 'Unknown error';
    } catch (e) { return e.toString(); }
  }

  Future<String?> deleteSchedule(String token, int id) async {
    try {
      final response = await http.delete(
        Uri.parse('$baseUrl/schedule/$id'),
        headers: {'Authorization': 'Bearer $token'},
      );
      if (response.statusCode == 204) return null;
      final Map<String, dynamic> error = jsonDecode(response.body);
      return error['message'] ?? 'Unknown error';
    } catch (e) { return e.toString(); }
  }

  Future<String?> updateSchedule(String token, int id, Map<String, dynamic> data) async {
    try {
      final response = await http.put(
        Uri.parse('$baseUrl/schedule/$id'),
        headers: {'Content-Type': 'application/json', 'Authorization': 'Bearer $token'},
        body: jsonEncode(data),
      );
      if (response.statusCode == 204) return null;
      final Map<String, dynamic> error = jsonDecode(response.body);
      return error['message'] ?? 'Unknown error';
    } catch (e) { return e.toString(); }
  }

  Future<String?> deleteAllClassSchedules(String token, int classId) async {
    try {
      final response = await http.delete(
        Uri.parse('$baseUrl/schedule/class/$classId'),
        headers: {'Authorization': 'Bearer $token'},
      );
      if (response.statusCode == 204) return null;
      final Map<String, dynamic> error = jsonDecode(response.body);
      return error['message'] ?? 'Unknown error';
    } catch (e) { return e.toString(); }
  }
}
