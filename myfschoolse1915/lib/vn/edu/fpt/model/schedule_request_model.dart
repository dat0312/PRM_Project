class ScheduleRequestModel {
  final int id;
  final int scheduleId;
  final int teacherId;
  final String requestType;
  final String reason;
  final String requestedDate;
  final String status;
  final String? teacherName;
  final String? scheduleDetails;
  final String? makeUpDate;
  final int? makeUpSlot;

  ScheduleRequestModel({
    required this.id,
    required this.scheduleId,
    required this.teacherId,
    required this.requestType,
    required this.reason,
    required this.requestedDate,
    required this.status,
    this.teacherName,
    this.scheduleDetails,
    this.makeUpDate,
    this.makeUpSlot,
  });

  factory ScheduleRequestModel.fromJson(Map<String, dynamic> json) {
    try {
      String details = '';
      if (json['schedule'] != null) {
        final s = json['schedule'];
        final cName = s['class']?['name'] ?? 'N/A';
        final rName = s['room']?['name'] ?? 'N/A';
        details = '$cName - ${s['subjectCode']} - Ca ${s['slot']} - $rName';
      }

      return ScheduleRequestModel(
        id: json['id'] ?? 0,
        scheduleId: json['scheduleId'] ?? 0,
        teacherId: json['teacherId'] ?? 0,
        requestType: json['requestType'] ?? '',
        reason: json['reason'] ?? '',
        requestedDate: json['requestedDate'] ?? '',
        status: json['status'] ?? 'Pending',
        teacherName: json['teacher']?['fullName'],
        scheduleDetails: details,
        makeUpDate: json['makeUpDate'],
        makeUpSlot: json['makeUpSlot'],
      );
    } catch (e) {
      print('Error parsing ScheduleRequestModel: $e');
      return ScheduleRequestModel(
        id: 0,
        scheduleId: 0,
        teacherId: 0,
        requestType: 'Unknown',
        reason: 'Error parsing data',
        requestedDate: '',
        status: 'Error',
      );
    }
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'scheduleId': scheduleId,
      'teacherId': teacherId,
      'requestType': requestType,
      'reason': reason,
      'requestedDate': requestedDate,
      'status': status,
      'makeUpDate': makeUpDate,
      'makeUpSlot': makeUpSlot,
    };
  }
}
