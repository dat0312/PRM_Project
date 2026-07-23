import 'package:myfschoolse1915/vn/edu/fpt/model/grade_model.dart';

class SubjectYearlyGrade {
  final int subjectId;
  final String subjectName;
  final GradeModel? semester1;
  final GradeModel? semester2;

  SubjectYearlyGrade(this.subjectId, this.subjectName, this.semester1, this.semester2);

  double? get yearlyAverage {
    final s1Avg = semester1?.averageScore;
    final s2Avg = semester2?.averageScore;

    if (s1Avg != null && s2Avg != null) {
      return (s1Avg + s2Avg) / 2;
    }
    
    return null;
  }
}

class AcademicRankHelper {
  static List<SubjectYearlyGrade> groupGradesBySubject(List<GradeModel> grades) {
    Map<String, Map<int, GradeModel>> grouped = {};
    Map<String, int> subjectIds = {};
    for (var grade in grades) {
      if (!grouped.containsKey(grade.subjectName)) {
        grouped[grade.subjectName] = {};
        subjectIds[grade.subjectName] = grade.subjectId ?? 0;
      }
      if (grade.semester != null) {
        grouped[grade.subjectName]![grade.semester!] = grade;
      }
    }

    List<SubjectYearlyGrade> result = [];
    grouped.forEach((subject, semesterMap) {
      result.add(SubjectYearlyGrade(
        subjectIds[subject] ?? 0,
        subject,
        semesterMap[1],
        semesterMap[2],
      ));
    });
    return result;
  }

  static String calculateRank(List<SubjectYearlyGrade> subjects) {
    if (subjects.isEmpty) return "Chưa xếp loại";

    List<double> averages = [];
    for (var s in subjects) {
      final avg = s.yearlyAverage;
      if (avg == null) return "Chưa xếp loại"; // Missing grades for a subject
      averages.add(avg);
    }

    bool allGte65 = averages.every((a) => a >= 6.5);
    bool allGte50 = averages.every((a) => a >= 5.0);
    bool noLt35 = averages.every((a) => a >= 3.5);
    
    int countGte90 = averages.where((a) => a >= 9.0).length;
    int countGte80 = averages.where((a) => a >= 8.0).length;
    int countGte65 = averages.where((a) => a >= 6.5).length;
    int countGte50 = averages.where((a) => a >= 5.0).length;

    // Học sinh Xuất sắc: Tất cả >= 6.5 + ít nhất 6 môn >= 9.0
    if (allGte65 && countGte90 >= 6) {
      return "Học sinh Xuất sắc";
    }

    // Học sinh Giỏi: Tất cả >= 6.5 + ít nhất 6 môn >= 8.0
    if (allGte65 && countGte80 >= 6) {
      return "Học sinh Giỏi";
    }

    // Xếp loại Khá: Tất cả >= 5.0 + ít nhất 6 môn >= 6.5
    if (allGte50 && countGte65 >= 6) {
      return "Xếp loại Khá";
    }

    // Xếp loại Đạt: Ít nhất 6 môn >= 5.0 + Không có môn nào dưới 3.5
    if (countGte50 >= 6 && noLt35) {
      return "Xếp loại Đạt";
    }

    return "Xếp loại Chưa đạt";
  }

  static double? calculateTotalAverage(List<SubjectYearlyGrade> subjects) {
    if (subjects.isEmpty) return null;
    double total = 0;
    int count = 0;
    for (var s in subjects) {
      if (s.yearlyAverage != null) {
        total += s.yearlyAverage!;
        count++;
      }
    }
    if (count == 0) return null;
    return total / count;
  }
}
