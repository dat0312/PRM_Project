import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/schedule_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/schedule_controller.dart';
import 'package:intl/intl.dart';

class MakeupRequestDialog extends StatefulWidget {
  final LoginModel user;
  final ScheduleModel schedule;

  const MakeupRequestDialog({super.key, required this.user, required this.schedule});

  @override
  State<MakeupRequestDialog> createState() => _MakeupRequestDialogState();
}

class _MakeupRequestDialogState extends State<MakeupRequestDialog> {
  final _reasonController = TextEditingController();
  DateTime? _selectedDate;
  int? _selectedSlot;
  bool _isLoadingSlots = false;
  List<int> _availableSlots = [];
  bool _isSubmitting = false;

  final ScheduleController _scheduleController = ScheduleController();

  Future<void> _pickDate() async {
    final date = await showDatePicker(
      context: context,
      initialDate: DateTime.now().add(const Duration(days: 1)),
      firstDate: DateTime.now(),
      lastDate: DateTime.now().add(const Duration(days: 60)),
    );
    if (date != null) {
      setState(() {
        _selectedDate = date;
        _selectedSlot = null;
        _isLoadingSlots = true;
      });
      _fetchAvailableSlots(date);
    }
  }

  Future<void> _fetchAvailableSlots(DateTime date) async {
    // Lấy lịch của lớp trong ngày đó để tìm slot rảnh
    final startOfDay = DateTime(date.year, date.month, date.day, 0, 0, 0);
    final endOfDay = DateTime(date.year, date.month, date.day, 23, 59, 59);
    
    final schedules = await _scheduleController.fetchSchedules(
      widget.user.token, 
      startOfDay, 
      endOfDay,
      classId: widget.schedule.classId
    );
    
    final occupied = schedules.map((s) => s.rawSlot).toSet();
    final allSlots = List.generate(8, (index) => index + 1);
    
    setState(() {
      _availableSlots = allSlots.where((slot) => !occupied.contains(slot)).toList();
      _isLoadingSlots = false;
    });
  }

  Future<void> _submitRequest() async {
    if (_selectedDate == null || _selectedSlot == null || _reasonController.text.trim().isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Vui lòng điền đủ thông tin')));
      return;
    }
    
    setState(() => _isSubmitting = true);

    // Encode metadata as JSON in Content
    final metadata = {
      "Type": "MAKEUP",
      "ScheduleId": widget.schedule.id,
      "NewDate": DateFormat('yyyy-MM-dd').format(_selectedDate!),
      "NewSlot": _selectedSlot,
      "Reason": _reasonController.text.trim()
    };

    final reqData = {
      "title": "Đơn xin dạy bù lớp ${widget.schedule.className} - Môn ${widget.schedule.subjectName}",
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
        ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Đã gửi đơn dạy bù thành công!')));
        Navigator.pop(context);
      } else {
        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text(error)));
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text('Đơn Xin Dạy Bù', style: TextStyle(color: Colors.blue)),
      content: SizedBox(
        width: 400,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text('Lớp: ${widget.schedule.className} - Môn: ${widget.schedule.subjectName}'),
            Text('Lịch cũ: Tiết ${widget.schedule.rawSlot}, ${DateFormat('dd/MM/yyyy').format(widget.schedule.date)}'),
            const SizedBox(height: 16),
            TextField(
              controller: _reasonController,
              decoration: const InputDecoration(labelText: 'Lý do xin dạy bù', border: OutlineInputBorder()),
              maxLines: 3,
            ),
            const SizedBox(height: 16),
            ListTile(
              contentPadding: EdgeInsets.zero,
              title: Text(_selectedDate == null ? 'Chọn ngày dạy bù' : 'Ngày: ${DateFormat('dd/MM/yyyy').format(_selectedDate!)}'),
              trailing: const Icon(Icons.calendar_today),
              onTap: _pickDate,
            ),
            if (_isLoadingSlots) 
              const Padding(
                padding: EdgeInsets.all(8.0),
                child: Center(child: CircularProgressIndicator()),
              )
            else if (_selectedDate != null) ...[
              const SizedBox(height: 8),
              const Text('Chọn Tiết bù:', style: TextStyle(fontWeight: FontWeight.bold)),
              const SizedBox(height: 8),
              Wrap(
                spacing: 8,
                runSpacing: 8,
                children: _availableSlots.map((slot) => ChoiceChip(
                  label: Text('Tiết $slot'),
                  selected: _selectedSlot == slot,
                  onSelected: (selected) {
                    setState(() => _selectedSlot = selected ? slot : null);
                  },
                )).toList(),
              )
            ]
          ],
        ),
      ),
      actions: [
        TextButton(onPressed: _isSubmitting ? null : () => Navigator.pop(context), child: const Text('Hủy')),
        ElevatedButton(
          onPressed: _isSubmitting ? null : _submitRequest,
          style: ElevatedButton.styleFrom(backgroundColor: Colors.blue),
          child: _isSubmitting 
            ? const SizedBox(width: 16, height: 16, child: CircularProgressIndicator(color: Colors.white, strokeWidth: 2))
            : const Text('Gửi đơn'),
        )
      ],
    );
  }
}
