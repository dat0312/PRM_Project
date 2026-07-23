class ClassModel {
  final int id;
  final String name;
  final int grade;
  final String? cohort;
  final int? startYear;
  final bool isGradeLocked;
  final bool isHomeroom;
  final int? homeroomTeacherId;
  final String? homeroomTeacherName;

  ClassModel({
    required this.id,
    required this.name,
    required this.grade,
    this.cohort,
    this.startYear,
    required this.isGradeLocked,
    this.isHomeroom = false,
    this.homeroomTeacherId,
    this.homeroomTeacherName,
  });

  factory ClassModel.fromJson(Map<String, dynamic> json) {
    return ClassModel(
      id: json['id'],
      name: json['name'] ?? '',
      grade: json['grade'] ?? 0,
      cohort: json['cohort'],
      startYear: json['startYear'],
      isGradeLocked: json['isGradeLocked'] ?? false,
      isHomeroom: json['isHomeroom'] ?? false,
      homeroomTeacherId: json['homeroomTeacherId'],
      homeroomTeacherName: json['homeroomTeacherName'],
    );
  }
}
