class RequestModel {
  final int id;
  final String title;
  final String content;
  final int senderId;
  final String senderName;
  final String senderEmail;
  final String date;
  final String status;
  final String category;
  final String receiverIds;

  RequestModel({
    required this.id,
    required this.title,
    required this.content,
    required this.senderId,
    required this.senderName,
    required this.senderEmail,
    required this.date,
    required this.status,
    required this.category,
    required this.receiverIds,
  });

  factory RequestModel.fromJson(Map<String, dynamic> json) {
    return RequestModel(
      id: json['id'] ?? 0,
      title: json['title'] ?? '',
      content: json['content'] ?? '',
      senderId: json['senderId'] ?? 0,
      senderName: json['senderName'] ?? '',
      senderEmail: json['senderEmail'] ?? '',
      date: json['date'] ?? '',
      status: json['status'] ?? '',
      category: json['category'] ?? '',
      receiverIds: json['receiverIds'] ?? '',
    );
  }
}