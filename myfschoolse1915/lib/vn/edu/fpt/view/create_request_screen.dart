import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/request_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'dart:async';

class CreateRequestScreen extends StatefulWidget {
  final LoginModel user;
  const CreateRequestScreen({super.key, required this.user});

  @override
  State<CreateRequestScreen> createState() => _CreateRequestScreenState();
}

class _CreateRequestScreenState extends State<CreateRequestScreen> {
  final RequestController _controller = RequestController();
  final _titleController = TextEditingController();
  final _contentController = TextEditingController();
  
  String? _selectedRequestType;
  Map<String, dynamic>? _selectedUser;
  bool _isLoading = false;

  void _submit() async {
    if (_titleController.text.trim().isEmpty || _contentController.text.trim().isEmpty || _selectedUser == null) {
      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Vui lòng điền đầy đủ thông tin và chọn người nhận')));
      return;
    }

    setState(() => _isLoading = true);
    try {
      String receiverId = _selectedUser!['id'].toString();
      await _controller.createRequest(_titleController.text.trim(), _contentController.text.trim(), widget.user.id, receiverId);
      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Gửi đơn thành công')));
      Navigator.pop(context, true);
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Lỗi: $e')));
    } finally {
      if (mounted) setState(() => _isLoading = false);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: const Text('Soạn tin nhắn / Đơn', style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18)),
        centerTitle: true,
        leading: IconButton(
          icon: const Icon(Icons.close, color: Colors.white),
          onPressed: () => Navigator.pop(context),
        ),
      ),
      body: _isLoading ? const Center(child: CircularProgressIndicator()) : SingleChildScrollView(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            const Text('Người nhận (Email):', style: TextStyle(fontWeight: FontWeight.bold)),
            const SizedBox(height: 8),
            Autocomplete<Map<String, dynamic>>(
              displayStringForOption: (option) => option['email'] as String,
              optionsBuilder: (TextEditingValue textEditingValue) async {
                if (textEditingValue.text.length < 2) {
                  return const Iterable<Map<String, dynamic>>.empty();
                }
                return await _controller.searchEmails(textEditingValue.text);
              },
              onSelected: (Map<String, dynamic> selection) {
                setState(() => _selectedUser = selection);
              },
              fieldViewBuilder: (context, textEditingController, focusNode, onFieldSubmitted) {
                return TextField(
                  controller: textEditingController,
                  focusNode: focusNode,
                  decoration: InputDecoration(
                    hintText: 'Nhập email người nhận...',
                    border: OutlineInputBorder(borderRadius: BorderRadius.circular(8)),
                    contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
                    filled: true,
                    fillColor: Colors.white,
                  ),
                );
              },
            ),
            if (_selectedUser != null)
              Padding(
                padding: const EdgeInsets.only(top: 8),
                child: Text('Đã chọn: ${_selectedUser!['fullName']}', style: const TextStyle(color: Colors.green, fontWeight: FontWeight.bold)),
              ),
            const SizedBox(height: 16),
            const Text('Tiêu đề:', style: TextStyle(fontWeight: FontWeight.bold)),
            const SizedBox(height: 8),
            DropdownButtonFormField<String>(
              value: _selectedRequestType,
              decoration: InputDecoration(
                hintText: 'Chọn loại đơn...',
                border: OutlineInputBorder(borderRadius: BorderRadius.circular(8)),
                contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
                filled: true,
                fillColor: Colors.white,
              ),
              items: (widget.user.roles.contains('Parent') 
                  ? ['Đơn xin nghỉ học', 'Đơn xin phúc khảo', 'Đơn xin chuyển đổi môn học', 'Ý kiến phụ huynh', 'Khác']
                  : ['Đơn xin phúc khảo', 'Đơn xin tham gia câu lạc bộ', 'Đơn xin chuyển đổi môn học', 'Ý kiến đóng góp', 'Khác'])
                  .map((type) => DropdownMenuItem<String>(value: type, child: Text(type)))
                  .toList(),
              onChanged: (value) {
                setState(() => _selectedRequestType = value);
                _titleController.text = value ?? '';
              },
            ),
            const SizedBox(height: 16),
            const Text('Nội dung:', style: TextStyle(fontWeight: FontWeight.bold)),
            const SizedBox(height: 8),
            TextField(
              controller: _contentController,
              maxLines: 8,
              decoration: InputDecoration(
                hintText: 'Nhập nội dung...',
                border: OutlineInputBorder(borderRadius: BorderRadius.circular(8)),
                contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
                filled: true,
                fillColor: Colors.white,
              ),
            ),
            const SizedBox(height: 24),
            ElevatedButton(
              onPressed: _submit,
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.orange,
                padding: const EdgeInsets.symmetric(vertical: 16),
                shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(8)),
              ),
              child: const Text('Gửi', style: TextStyle(color: Colors.white, fontSize: 16, fontWeight: FontWeight.bold)),
            )
          ],
        ),
      ),
    );
  }
}
