import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/request_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/request_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/request_detail_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/create_request_screen.dart';

class RequestScreen extends StatefulWidget {
  final LoginModel user;
  const RequestScreen({super.key, required this.user});

  @override
  State<RequestScreen> createState() => _RequestScreenState();
}

class _RequestScreenState extends State<RequestScreen> {
  final RequestController _controller = RequestController();
  List<RequestModel> _allRequests = [];
  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _loadRequests();
  }

  Future<void> _loadRequests() async {
    setState(() => _isLoading = true);
    try {
      _allRequests = await _controller.fetchUserRequests(widget.user.id);
    } catch (e) {
      debugPrint("Error loading requests: $e");
    } finally {
      if (mounted) setState(() => _isLoading = false);
    }
  }

  @override
  Widget build(BuildContext context) {
    List<RequestModel> sentRequests = _allRequests.where((r) => r.senderId == widget.user.id).toList();
    
    // Đơn nhận là những đơn mà người nhận có Id của mình hoặc ALL, và mình không phải là người gửi
    String myId = widget.user.id.toString();
    List<RequestModel> receivedRequests = _allRequests.where((r) => 
      r.senderId != widget.user.id && (r.receiverIds == "ALL" || r.receiverIds.split(',').contains(myId))
    ).toList();

    return DefaultTabController(
      length: 2,
      child: Scaffold(
        backgroundColor: const Color(0xFFF8F9FA),
        appBar: AppBar(
          backgroundColor: Colors.orange,
          elevation: 0,
          centerTitle: true,
          title: const Text('Đơn từ', style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18)),
          leading: IconButton(
            icon: const Icon(Icons.chevron_left, color: Colors.white),
            onPressed: () => Navigator.pop(context),
          ),
          bottom: const TabBar(
            labelColor: Colors.white,
            unselectedLabelColor: Colors.white70,
            indicatorColor: Colors.white,
            indicatorWeight: 3,
            tabs: [
              Tab(text: 'Đơn nhận'),
              Tab(text: 'Đơn gửi'),
            ],
          ),
        ),
        body: _isLoading 
          ? const Center(child: CircularProgressIndicator(color: Colors.orange))
          : TabBarView(
              children: [
                _buildRequestList(receivedRequests, isReceivedTab: true),
                _buildRequestList(sentRequests, isReceivedTab: false),
              ],
            ),
        floatingActionButton: widget.user.roles.contains('Student')
            ? null
            : FloatingActionButton.extended(
                onPressed: () async {
                  bool? result = await Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) =>
                            CreateRequestScreen(user: widget.user)),
                  );
                  if (result == true) {
                    _loadRequests();
                  }
                },
                backgroundColor: Colors.orange,
                icon: const Icon(Icons.add, color: Colors.white),
                label: const Text("Tạo đơn mới",
                    style: TextStyle(
                        color: Colors.white, fontWeight: FontWeight.bold)),
              ),
      ),
    );
  }

  Widget _buildRequestList(List<RequestModel> requests, {required bool isReceivedTab}) {
    if (requests.isEmpty) {
      return const Center(child: Text('Không có đơn nào.', style: TextStyle(color: Colors.grey)));
    }
    return ListView.builder(
      padding: const EdgeInsets.all(16),
      itemCount: requests.length,
      itemBuilder: (context, index) {
        final request = requests[index];
        return _buildRequestCard(request, isReceivedTab);
      },
    );
  }

  Widget _buildRequestCard(RequestModel request, bool isReceivedTab) {
    Color statusColor;
    switch (request.status) {
      case 'Đã duyệt': case 'Đã nhận': statusColor = Colors.green; break;
      case 'Chờ duyệt': case 'Đang chờ': statusColor = Colors.orange; break;
      case 'Từ chối': statusColor = Colors.red; break;
      default: statusColor = Colors.grey;
    }

    String subtext = isReceivedTab 
      ? 'Từ: ${request.senderName.isEmpty ? "Hệ thống" : request.senderName}' 
      : 'Tới: ${request.receiverIds == "ALL" ? "Tất cả" : "Một số người nhận"}';

    return GestureDetector(
      onTap: () {
        Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => RequestDetailScreen(request: request, user: widget.user)),
        );
      },
      child: Container(
        margin: const EdgeInsets.only(bottom: 16),
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(16),
          boxShadow: [BoxShadow(color: Colors.black.withOpacity(0.03), blurRadius: 10, offset: const Offset(0, 4))],
        ),
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Expanded(
                    child: Text(request.title, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16), maxLines: 1, overflow: TextOverflow.ellipsis),
                  ),
                  const SizedBox(width: 8),
                  Container(
                    padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
                    decoration: BoxDecoration(
                      color: statusColor.withOpacity(0.1),
                      borderRadius: BorderRadius.circular(8),
                    ),
                    child: Text(
                      request.status,
                      style: TextStyle(color: statusColor, fontWeight: FontWeight.bold, fontSize: 11),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 8),
              Text(subtext, style: TextStyle(color: Colors.grey.shade600, fontSize: 13)),
              const Divider(height: 24),
              Row(
                children: [
                  const Icon(Icons.calendar_today, size: 14, color: Colors.grey),
                  const SizedBox(width: 6),
                  Text(request.date, style: const TextStyle(color: Colors.grey, fontSize: 12)),
                  const Spacer(),
                  const Text("Xem chi tiết", style: TextStyle(color: Colors.blue, fontWeight: FontWeight.bold, fontSize: 12)),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
