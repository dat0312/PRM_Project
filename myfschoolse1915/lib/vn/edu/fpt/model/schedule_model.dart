class ScheduleModel {
  final int id;
  final String slot;
  final String startTime;
  final String endTime;
  final String room;
  final String subjectCode;
  final String subjectName;
  final int sessionNo;
  final String className;
  final String lecturer;
  final String status;
  final String dateLabel;
  final int classSize;

  // Raw fields for editing
  final int roomId;
  final int teacherId;
  final int classId;
  final DateTime date;
  final int rawSlot;

  ScheduleModel({
    required this.id,
    required this.slot,
    required this.startTime,
    required this.endTime,
    required this.room,
    required this.subjectCode,
    required this.subjectName,
    required this.sessionNo,
    required this.className,
    required this.lecturer,
    required this.status,
    required this.dateLabel,
    required this.classSize,
    required this.roomId,
    required this.teacherId,
    required this.classId,
    required this.date,
    required this.rawSlot,
  });

  factory ScheduleModel.fromJson(Map<String, dynamic> json) {
    return ScheduleModel(
      id: json['id'] ?? 0,
      slot: json['slot'] ?? '',
      startTime: json['startTime'] ?? '',
      endTime: json['endTime'] ?? '',
      room: json['room'] ?? '',
      subjectCode: json['subjectCode'] ?? '',
      subjectName: json['subjectName'] ?? json['subjectCode'] ?? '',
      sessionNo: json['sessionNo'] ?? 1,
      className: json['className'] ?? '',
      lecturer: json['lecturer'] ?? '',
      status: json['status'] ?? '',
      dateLabel: json['dateLabel'] ?? '',
      classSize: json['classSize'] ?? 0,
      roomId: json['roomId'] ?? 0,
      teacherId: json['teacherId'] ?? 0,
      classId: json['classId'] ?? 0,
      date: json['date'] != null ? DateTime.parse(json['date']) : DateTime.now(),
      rawSlot: json['rawSlot'] ?? 0,
    );
  }
}