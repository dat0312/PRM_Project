import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/club_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/club_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/club_detail_screen.dart';

class ClubScreen extends StatefulWidget {
  final LoginModel user;
  const ClubScreen({super.key, required this.user});

  @override
  State<ClubScreen> createState() => _ClubScreenState();
}

class _ClubScreenState extends State<ClubScreen> {
  final ClubController _controller = ClubController();
  List<ClubModel> _allClubs = [];
  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _fetchClubs();
  }

  Future<void> _fetchClubs() async {
    setState(() => _isLoading = true);
    try {
      _allClubs = await _controller.fetchClubs();
    } catch (e) {
      print('Error fetching clubs: $e');
    } finally {
      if (mounted) setState(() => _isLoading = false);
    }
  }

  void _showJoinDialog(ClubModel club) {
    final reasonController = TextEditingController();
    showDialog(
      context: context,
      builder: (ctx) => AlertDialog(
        title: Text('Tham gia ${club.name}'),
        content: TextField(
          controller: reasonController,
          decoration: const InputDecoration(
            hintText: 'Nhập lý do tham gia (Tùy chọn)',
            border: OutlineInputBorder(),
          ),
          maxLines: 3,
        ),
        actions: [
          TextButton(onPressed: () => Navigator.pop(ctx), child: const Text('Hủy')),
          ElevatedButton(
            style: ElevatedButton.styleFrom(backgroundColor: Colors.orange),
            onPressed: () async {
              Navigator.pop(ctx);
              try {
                await _controller.joinRequest(club.id, widget.user.id, reasonController.text);
                ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Gửi đơn thành công')));
              } catch (e) {
                ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text(e.toString())));
              }
            },
            child: const Text('Gửi yêu cầu', style: TextStyle(color: Colors.white)),
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    final joinedClubs = _allClubs.where((c) => c.memberIds.contains(widget.user.id) || c.presidentId == widget.user.id).toList();
    final otherClubs = _allClubs.where((c) => !c.memberIds.contains(widget.user.id) && c.presidentId != widget.user.id).toList();

    return DefaultTabController(
      length: 2,
      child: Scaffold(
        backgroundColor: const Color(0xFFF8F9FA),
        appBar: AppBar(
          backgroundColor: Colors.orange,
          elevation: 0,
          centerTitle: true,
          title: const Text(
            'Câu lạc bộ',
            style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 18),
          ),
          leading: IconButton(
            icon: const Icon(Icons.chevron_left, color: Colors.white),
            onPressed: () => Navigator.pop(context),
          ),
          bottom: const TabBar(
            labelColor: Colors.white,
            unselectedLabelColor: Colors.white70,
            indicatorColor: Colors.white,
            tabs: [
              Tab(text: "Đã tham gia"),
              Tab(text: "Khám phá"),
            ],
          ),
        ),
        body: _isLoading 
          ? const Center(child: CircularProgressIndicator())
          : TabBarView(
              children: [
                _buildClubList(joinedClubs, isJoinedView: true),
                _buildClubList(otherClubs, isJoinedView: false),
              ],
            ),
      ),
    );
  }

  Widget _buildClubList(List<ClubModel> clubs, {required bool isJoinedView}) {
    if (clubs.isEmpty) {
      return Center(
        child: Text(
          isJoinedView ? "Bạn chưa tham gia câu lạc bộ nào." : "Không có câu lạc bộ mới.",
          style: const TextStyle(color: Colors.grey, fontSize: 16),
        ),
      );
    }

    return ListView.builder(
      padding: const EdgeInsets.all(16),
      itemCount: clubs.length,
      itemBuilder: (context, index) {
        final club = clubs[index];
        return Card(
          elevation: 2,
          margin: const EdgeInsets.only(bottom: 16),
          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
          child: InkWell(
            onTap: isJoinedView ? () {
              Navigator.push(context, MaterialPageRoute(builder: (context) => ClubDetailScreen(club: club, user: widget.user)))
                .then((_) => _fetchClubs());
            } : null,
            child: Padding(
              padding: const EdgeInsets.all(16),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        club.name,
                        style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                      ),
                      Container(
                        padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
                        decoration: BoxDecoration(color: Colors.blue.withOpacity(0.1), borderRadius: BorderRadius.circular(8)),
                        child: Text(club.type, style: const TextStyle(color: Colors.blue, fontSize: 12)),
                      )
                    ],
                  ),
                  const SizedBox(height: 8),
                  Text(club.description, style: TextStyle(color: Colors.grey.shade600, fontSize: 14, height: 1.4)),
                  const SizedBox(height: 12),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text('${club.memberCount} thành viên', style: const TextStyle(color: Colors.grey, fontWeight: FontWeight.bold)),
                      if (!isJoinedView)
                        ElevatedButton(
                          onPressed: () => _showJoinDialog(club),
                          style: ElevatedButton.styleFrom(
                            backgroundColor: Colors.orange,
                            shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(8)),
                            padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                          ),
                          child: const Text('Tham gia', style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold)),
                        )
                    ],
                  )
                ],
              ),
            ),
          ),
        );
      },
    );
  }
}
