class SubjectModel {
  final int id;
  final String code;
  final String name;
  final int grade;
  final String group;

  SubjectModel({
    required this.id,
    required this.code,
    required this.name,
    required this.grade,
    required this.group,
  });

  factory SubjectModel.fromJson(Map<String, dynamic> json) {
    return SubjectModel(
      id: json['id'],
      code: json['code'],
      name: json['name'],
      grade: json['grade'],
      group: json['group'],
    );
  }
}
