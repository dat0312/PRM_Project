class GradeModel {
  final int id;
  final int? studentId;
  final String? studentName;
  final int? subjectId;
  final String subjectName;
  final int? classId;
  final String? academicYear;
  final int? semester;
  final double? attendanceScore;
  final double? oralScore1;
  final double? oralScore2;
  final double? fifteenMinScore1;
  final double? fifteenMinScore2;
  final double? midtermScore;
  final double? finalScore;
  final bool? isGradeLocked;

  GradeModel({
    required this.id,
    this.studentId,
    this.studentName,
    this.subjectId,
    required this.subjectName,
    this.classId,
    this.academicYear,
    this.semester,
    this.attendanceScore,
    this.oralScore1,
    this.oralScore2,
    this.fifteenMinScore1,
    this.fifteenMinScore2,
    this.midtermScore,
    this.finalScore,
    this.isGradeLocked,
  });

  factory GradeModel.fromJson(Map<String, dynamic> json) {
    return GradeModel(
      id: json['id'],
      studentId: json['studentId'],
      studentName: json['studentName'],
      subjectId: json['subjectId'],
      subjectName: json['subjectName'] ?? '',
      classId: json['classId'],
      academicYear: json['academicYear'],
      semester: json['semester'],
      attendanceScore: json['attendanceScore']?.toDouble(),
      oralScore1: json['oralScore1']?.toDouble(),
      oralScore2: json['oralScore2']?.toDouble(),
      fifteenMinScore1: json['fifteenMinScore1']?.toDouble(),
      fifteenMinScore2: json['fifteenMinScore2']?.toDouble(),
      midtermScore: json['midtermScore']?.toDouble(),
      finalScore: json['finalScore']?.toDouble(),
      isGradeLocked: json['isGradeLocked'],
    );
  }

  double? get averageScore {
    int countRegular = 0;
    double sumRegular = 0;
    if (attendanceScore != null) { countRegular++; sumRegular += attendanceScore!; }
    if (oralScore1 != null) { countRegular++; sumRegular += oralScore1!; }
    if (oralScore2 != null) { countRegular++; sumRegular += oralScore2!; }
    if (fifteenMinScore1 != null) { countRegular++; sumRegular += fifteenMinScore1!; }
    if (fifteenMinScore2 != null) { countRegular++; sumRegular += fifteenMinScore2!; }
    
    int totalCoefficient = countRegular;
    double totalSum = sumRegular;
    
    if (midtermScore != null) {
      totalCoefficient += 2;
      totalSum += midtermScore! * 2;
    }
    
    if (finalScore != null) {
      totalCoefficient += 3;
      totalSum += finalScore! * 3;
    }
    
    if (totalCoefficient == 0) return null;
    return totalSum / totalCoefficient;
  }
}