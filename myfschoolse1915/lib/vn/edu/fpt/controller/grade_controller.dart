import 'package:myfschoolse1915/vn/edu/fpt/utils/api_config.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:myfschoolse1915/vn/edu/fpt/model/grade_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/class_model.dart';

class GradeController {
  final String baseUrl = '${ApiConfig.baseUrl}/api';

  Future<List<ClassModel>> fetchAllClasses(String token) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/Class'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        List<dynamic> jsonList = json.decode(response.body);
        return jsonList.map((json) => ClassModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<List<dynamic>> fetchSubjects(String token) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/Subject'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        return json.decode(response.body);
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<List<ClassModel>> fetchMyClasses(String token, {String? academicYear}) async {
    try {
      String url = '$baseUrl/Class/my-classes';
      if (academicYear != null && academicYear.isNotEmpty) {
        url += '?academicYear=$academicYear';
      }
      final response = await http.get(
        Uri.parse(url),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        List<dynamic> jsonList = json.decode(response.body);
        return jsonList.map((json) => ClassModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<List<GradeModel>> fetchMyGrades(String token) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/Grades/my-grades'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        List<dynamic> jsonList = json.decode(response.body);
        return jsonList.map((json) => GradeModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<List<GradeModel>> fetchClassGrades(String token, int classId) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/Grades/class/$classId'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        List<dynamic> jsonList = json.decode(response.body);
        return jsonList.map((json) => GradeModel.fromJson(json)).toList();
      }
      return [];
    } catch (e) {
      return [];
    }
  }

  Future<bool> toggleLockGrade(String token, int classId, bool isLocked) async {
    try {
      final response = await http.put(
        Uri.parse('$baseUrl/Grades/class/$classId/lock'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
        body: json.encode(isLocked),
      );
      return response.statusCode == 200;
    } catch (e) {
      return false;
    }
  }

  Future<bool> toggleLockAllGrades(String token, bool isLocked) async {
    try {
      final response = await http.put(
        Uri.parse('$baseUrl/Grades/lock-all'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
        body: json.encode(isLocked),
      );
      return response.statusCode == 200;
    } catch (e) {
      return false;
    }
  }

  Future<bool> updateGrade(String token, Map<String, dynamic> gradeDto) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/Grades'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token',
        },
        body: json.encode(gradeDto),
      );
      return response.statusCode == 200;
    } catch (e) {
      return false;
    }
  }

  Future<List<String>> fetchAcademicYears() async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/Class/academic-years'),
      );
      if (response.statusCode == 200) {
        List<dynamic> jsonList = json.decode(response.body);
        return jsonList.map((e) => e.toString()).toList();
      }
      return ['2025-2026', '2024-2025', '2023-2024']; // fallback
    } catch (e) {
      return ['2025-2026', '2024-2025', '2023-2024']; // fallback
    }
  }

  Future<List<int>?> exportExcel(String token, int classId, int subjectId, String academicYear) async {
    try {
      final response = await http.get(
        Uri.parse('$baseUrl/Grades/export/$classId?subjectId=$subjectId&academicYear=$academicYear'),
        headers: {
          'Authorization': 'Bearer $token',
        },
      );
      if (response.statusCode == 200) {
        return response.bodyBytes;
      }
      return null;
    } catch (e) {
      return null;
    }
  }

  Future<bool> importExcel(String token, int classId, int subjectId, String academicYear, List<int> fileBytes, String fileName) async {
    try {
      var request = http.MultipartRequest('POST', Uri.parse('$baseUrl/Grades/import/$classId?subjectId=$subjectId&academicYear=$academicYear'));
      request.headers['Authorization'] = 'Bearer $token';
      request.files.add(http.MultipartFile.fromBytes('file', fileBytes, filename: fileName));
      
      var response = await request.send();
      return response.statusCode == 200;
    } catch (e) {
      return false;
    }
  }
}
