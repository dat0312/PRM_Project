class ClubModel {
  final int id;
  final String name;
  final String code;
  final String type;
  final String status;
  final String description;
  final int? presidentId;
  final String? presidentName;
  final int memberCount;
  final List<int> memberIds;

  ClubModel({
    required this.id,
    required this.name,
    required this.code,
    required this.type,
    required this.status,
    this.description = '',
    this.presidentId,
    this.presidentName,
    required this.memberCount,
    this.memberIds = const [],
  });

  factory ClubModel.fromJson(Map<String, dynamic> json) {
    return ClubModel(
      id: json['id'] ?? 0,
      name: json['name'] ?? '',
      code: json['code'] ?? '',
      type: json['type'] ?? '',
      status: json['status'] ?? 'HOẠT ĐỘNG',
      description: json['description'] ?? '',
      presidentId: json['presidentId'],
      presidentName: json['presidentName'],
      memberCount: json['memberCount'] ?? 0,
      memberIds: json['memberIds'] != null ? List<int>.from(json['memberIds']) : [],
    );
  }
}

class ClubStatsModel {
  final int totalClubs;
  final int totalMembers;
  final int eventsThisMonth;
  final int pendingProposals;

  ClubStatsModel({
    required this.totalClubs,
    required this.totalMembers,
    required this.eventsThisMonth,
    required this.pendingProposals,
  });

  factory ClubStatsModel.fromJson(Map<String, dynamic> json) {
    return ClubStatsModel(
      totalClubs: json['totalClubs'] ?? 0,
      totalMembers: json['totalMembers'] ?? 0,
      eventsThisMonth: json['eventsThisMonth'] ?? 0,
      pendingProposals: json['pendingProposals'] ?? 0,
    );
  }
}