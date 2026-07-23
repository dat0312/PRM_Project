class LoginModel {
  final int id;
  final String fullName;
  final String className;
  final String studentId;
  final String phoneNumber;
  final String email;
  final String token;
  final String avatarUrl;
  final List<String> roles;

  LoginModel({
    required this.id,
    required this.fullName,
    required this.className,
    required this.studentId,
    required this.phoneNumber,
    required this.email,
    required this.token,
    required this.avatarUrl,
    this.roles = const [],
  });

  factory LoginModel.fromJson(Map<String, dynamic> json) {
    return LoginModel(
      id: json['id'] ?? 0,
      fullName: json['fullName'] ?? '',
      className: json['className'] ?? '',
      studentId: json['studentId'] ?? '',
      phoneNumber: json['phoneNumber'] ?? '',
      email: json['email'] ?? '',
      token: json['token'] ?? '',
      avatarUrl: json['avatarUrl'] ?? '',
      roles: (json['roles'] as List<dynamic>?)?.map((e) => e.toString()).toList() ?? [],
    );
  }
}
