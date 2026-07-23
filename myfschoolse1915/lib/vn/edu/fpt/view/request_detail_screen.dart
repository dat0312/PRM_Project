import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/request_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';

class RequestDetailScreen extends StatelessWidget {
  final RequestModel request;
  final LoginModel user;

  const RequestDetailScreen({super.key, required this.request, required this.user});

  @override
  Widget build(BuildContext context) {
    bool isReceived = request.senderId != user.id;

    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: const Text('Chi tiết đơn từ', style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18)),
        centerTitle: true,
        leading: IconButton(
          icon: const Icon(Icons.chevron_left, color: Colors.white),
          onPressed: () => Navigator.pop(context),
        ),
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16),
        child: Card(
          elevation: 2,
          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
          child: Padding(
            padding: const EdgeInsets.all(20),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(request.title, style: const TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
                const SizedBox(height: 16),
                _buildInfoRow('Thời gian:', request.date),
                _buildInfoRow('Trạng thái:', request.status),
                _buildInfoRow('Người gửi:', request.senderName.isEmpty ? 'Hệ thống' : '${request.senderName} (${request.senderEmail})'),
                const Divider(height: 32),
                const Text('Nội dung:', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Colors.grey)),
                const SizedBox(height: 12),
                Text(
                  request.content.isEmpty ? '(Không có nội dung)' : request.content,
                  style: const TextStyle(fontSize: 15, height: 1.5),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildInfoRow(String label, String value) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          SizedBox(width: 90, child: Text(label, style: const TextStyle(color: Colors.grey, fontWeight: FontWeight.w500))),
          Expanded(child: Text(value, style: const TextStyle(fontWeight: FontWeight.w500))),
        ],
      ),
    );
  }
}
