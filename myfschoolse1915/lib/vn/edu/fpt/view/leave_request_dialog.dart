import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/schedule_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/schedule_controller.dart';
import 'package:intl/intl.dart';

class LeaveRequestDialog extends StatefulWidget {
  final LoginModel user;
  final ScheduleModel schedule;

  const LeaveRequestDialog({super.key, required this.user, required this.schedule});

  @override
  State<LeaveRequestDialog> createState() => _LeaveRequestDialogState();
}

class _LeaveRequestDialogState extends State<LeaveRequestDialog> {
  final _reasonController = TextEditingController();
  bool _isSubmitting = false;

  final ScheduleController _scheduleController = ScheduleController();

  Future<void> _submitRequest() async {
    if (_reasonController.text.trim().isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Vui lòng nhập lý do xin nghỉ')));
      return;
    }
    
    setState(() => _isSubmitting = true);

    // Encode metadata as JSON in Content
    final metadata = {
      "Type": "LEAVE",
      "ScheduleId": widget.schedule.id,
      "Reason": _reasonController.text.trim()
    };

    final reqData = {
      "title": "Đơn xin nghỉ dạy lớp ${widget.schedule.className} - Môn ${widget.schedule.subjectName}",
      "content": jsonEncode(metadata),
      "category": "Lịch học",
      "status": "Chờ duyệt",
      "senderId": widget.user.id,
      "receiverIds": "ADMIN"
    };

    final error = await _scheduleController.createRequest(widget.user.token, reqData);
    if (mounted) {
      setState(() => _isSubmitting = false);
      if (error == null) {
        ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Đã gửi đơn xin nghỉ thành công!')));
        Navigator.pop(context);
      } else {
        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text(error)));
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text('Đơn Xin Nghỉ Dạy', style: TextStyle(color: Colors.red)),
      content: SizedBox(
        width: 400,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text('Lớp: ${widget.schedule.className} - Môn: ${widget.schedule.subjectName}'),
            Text('Lịch dạy: Tiết ${widget.schedule.rawSlot}, ${DateFormat('dd/MM/yyyy').format(widget.schedule.date)}'),
            const SizedBox(height: 16),
            TextField(
              controller: _reasonController,
              decoration: const InputDecoration(labelText: 'Lý do xin nghỉ', border: OutlineInputBorder()),
              maxLines: 3,
            ),
          ],
        ),
      ),
      actions: [
        TextButton(onPressed: _isSubmitting ? null : () => Navigator.pop(context), child: const Text('Hủy')),
        ElevatedButton(
          onPressed: _isSubmitting ? null : _submitRequest,
          style: ElevatedButton.styleFrom(backgroundColor: Colors.red),
          child: _isSubmitting 
            ? const SizedBox(width: 16, height: 16, child: CircularProgressIndicator(color: Colors.white, strokeWidth: 2))
            : const Text('Gửi đơn'),
        )
      ],
    );
  }
}
