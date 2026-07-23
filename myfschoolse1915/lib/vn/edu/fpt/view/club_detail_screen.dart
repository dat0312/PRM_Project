import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/club_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/club_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';

class ClubDetailScreen extends StatefulWidget {
  final ClubModel club;
  final LoginModel user;

  const ClubDetailScreen({super.key, required this.club, required this.user});

  @override
  State<ClubDetailScreen> createState() => _ClubDetailScreenState();
}

class _ClubDetailScreenState extends State<ClubDetailScreen> {
  final ClubController _controller = ClubController();
  List<dynamic> _members = [];
  List<dynamic> _pendingRequests = [];
  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _fetchData();
  }

  Future<void> _fetchData() async {
    setState(() => _isLoading = true);
    try {
      _members = await _controller.fetchClubMembers(widget.club.id);
      if (widget.club.presidentId == widget.user.id) {
        _pendingRequests = await _controller.fetchPendingRequests(widget.club.id);
      }
    } catch (e) {
      print('Error: $e');
    } finally {
      if (mounted) setState(() => _isLoading = false);
    }
  }

  void _removeMember(int memberId) async {
    bool confirm = await showDialog(
      context: context,
      builder: (ctx) => AlertDialog(
        title: const Text('Xác nhận xóa'),
        content: const Text('Bạn có chắc chắn muốn xóa thành viên này?'),
        actions: [
          TextButton(onPressed: () => Navigator.pop(ctx, false), child: const Text('Hủy')),
          TextButton(onPressed: () => Navigator.pop(ctx, true), child: const Text('Xóa', style: TextStyle(color: Colors.red))),
        ],
      ),
    ) ?? false;

    if (!confirm) return;

    try {
      await _controller.removeClubMember(widget.club.id, memberId);
      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Xóa thành công')));
      _fetchData();
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Lỗi: $e')));
    }
  }

  void _transferPresident() {
    showDialog(
      context: context,
      builder: (ctx) {
        final eligibleMembers = _members.where((m) => m['userId'] != widget.user.id).toList();
        if (eligibleMembers.isEmpty) {
          return AlertDialog(
            title: const Text('Chuyển chức'),
            content: const Text('Không có thành viên nào khác để chuyển chức.'),
            actions: [TextButton(onPressed: () => Navigator.pop(ctx), child: const Text('Đóng'))],
          );
        }

        return AlertDialog(
          title: const Text('Chọn Chủ nhiệm mới'),
          content: SizedBox(
            width: double.maxFinite,
            child: ListView.builder(
              shrinkWrap: true,
              itemCount: eligibleMembers.length,
              itemBuilder: (context, index) {
                final m = eligibleMembers[index];
                return ListTile(
                  leading: CircleAvatar(child: Text(m['name'][0])),
                  title: Text(m['name']),
                  subtitle: Text(m['email'] ?? ''),
                  onTap: () async {
                    Navigator.pop(ctx);
                    bool confirm = await showDialog(
                      context: context,
                      builder: (confirmCtx) => AlertDialog(
                        title: const Text('Xác nhận'),
                        content: Text('Bạn chắc chắn muốn nhường chức Chủ nhiệm cho ${m['name']}? Bạn sẽ trở thành thành viên bình thường.'),
                        actions: [
                          TextButton(onPressed: () => Navigator.pop(confirmCtx, false), child: const Text('Hủy')),
                          TextButton(
                            onPressed: () => Navigator.pop(confirmCtx, true),
                            child: const Text('Xác nhận', style: TextStyle(color: Colors.orange)),
                          ),
                        ],
                      ),
                    ) ?? false;

                    if (confirm) {
                      try {
                        await _controller.transferPresident(widget.club.id, widget.user.id, m['userId']);
                        ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Chuyển chức thành công!')));
                        Navigator.pop(context); // Go back to club list
                      } catch (e) {
                        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Lỗi: $e')));
                      }
                    }
                  },
                );
              },
            ),
          ),
          actions: [
            TextButton(onPressed: () => Navigator.pop(ctx), child: const Text('Hủy')),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    final isPresident = widget.club.presidentId == widget.user.id;
    final role = isPresident ? "Chủ nhiệm" : "Thành viên";

    return Scaffold(
      backgroundColor: const Color(0xFFF8F9FA),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: Text(widget.club.name, style: const TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18)),
        centerTitle: true,
        leading: IconButton(
          icon: const Icon(Icons.chevron_left, color: Colors.white),
          onPressed: () => Navigator.pop(context),
        ),
      ),
      body: _isLoading
          ? const Center(child: CircularProgressIndicator())
          : SingleChildScrollView(
              padding: const EdgeInsets.all(16),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  _buildInfoCard(role),
                  const SizedBox(height: 20),
                  if (isPresident) ...[
                    _buildPendingRequestsCard(),
                    const SizedBox(height: 20),
                    _buildMembersCard(true),
                  ] else ...[
                    _buildMembersCard(false),
                  ]
                ],
              ),
            ),
    );
  }

  Widget _buildInfoCard(String role) {
    return Card(
      elevation: 2,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
      child: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text("Thông tin chung", style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold, color: Colors.grey.shade800)),
            const Divider(),
            const SizedBox(height: 8),
            _buildRow("Loại:", widget.club.type),
            _buildRow("Trạng thái:", widget.club.status),
            _buildRow("Mô tả:", widget.club.description),
            const Divider(),
            _buildRow("Chức vụ của bạn:", role, isHighlight: true),
          ],
        ),
      ),
    );
  }

  Widget _buildPendingRequestsCard() {
    if (_pendingRequests.isEmpty) return const SizedBox();
    return Card(
      elevation: 2,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
      child: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text("Yêu cầu tham gia (${_pendingRequests.length})", style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold, color: Colors.orange.shade800)),
            const Divider(),
            ..._pendingRequests.map((req) => ListTile(
              contentPadding: EdgeInsets.zero,
              leading: CircleAvatar(child: Text(req['senderName'][0])),
              title: Text(req['senderName'], style: const TextStyle(fontWeight: FontWeight.bold)),
              subtitle: Text(req['content']),
              trailing: Row(
                mainAxisSize: MainAxisSize.min,
                children: [
                  IconButton(
                    icon: const Icon(Icons.close, color: Colors.red),
                    onPressed: () async {
                      try {
                        await _controller.rejectRequest(req['id']);
                        ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Đã từ chối')));
                        _fetchData();
                      } catch (e) {
                        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Lỗi: $e')));
                      }
                    },
                  ),
                  IconButton(
                    icon: const Icon(Icons.check, color: Colors.green),
                    onPressed: () async {
                      try {
                        await _controller.approveRequest(req['id']);
                        ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Đã duyệt')));
                        _fetchData();
                      } catch (e) {
                        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Lỗi: $e')));
                      }
                    },
                  ),
                ],
              ),
            )).toList(),
          ],
        ),
      ),
    );
  }

  Widget _buildMembersCard(bool isPresident) {
    return Card(
      elevation: 2,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
      child: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text("Thành viên (${_members.length})", style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold, color: Colors.grey.shade800)),
                if (isPresident)
                  TextButton(
                    onPressed: _transferPresident,
                    child: const Text("Chuyển chức", style: TextStyle(color: Colors.orange)),
                  )
              ],
            ),
            const Divider(),
            ..._members.map((m) {
              final isMe = m['userId'] == widget.user.id;
              final isPres = m['userId'] == widget.club.presidentId;
              return ListTile(
                contentPadding: EdgeInsets.zero,
                leading: CircleAvatar(
                  backgroundColor: isPres ? Colors.orange : Colors.grey.shade300,
                  child: Icon(isPres ? Icons.star : Icons.person, color: Colors.white),
                ),
                title: Text(m['name'] + (isMe ? ' (Bạn)' : ''), style: const TextStyle(fontWeight: FontWeight.bold)),
                subtitle: Text(m['email'] ?? ''),
                trailing: (isPresident && !isPres) ? IconButton(
                  icon: const Icon(Icons.person_remove, color: Colors.red),
                  onPressed: () => _removeMember(m['userId']),
                ) : null,
              );
            }).toList(),
          ],
        ),
      ),
    );
  }

  Widget _buildRow(String label, String value, {bool isHighlight = false}) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          SizedBox(width: 120, child: Text(label, style: const TextStyle(color: Colors.grey, fontWeight: FontWeight.w500))),
          Expanded(child: Text(value, style: TextStyle(fontWeight: isHighlight ? FontWeight.bold : FontWeight.normal, color: isHighlight ? Colors.orange : Colors.black87))),
        ],
      ),
    );
  }
}
