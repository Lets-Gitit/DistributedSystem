package mid2021;

import java.util.ArrayList;
import java.util.Scanner;

public class Order implements Manageable {
	// 2 kim 20201010 F3195 3 F3135 1 F3124 1 0
	int id;
	User user;
	String date;
	int point;  // 주문금액 포인트
	int total;  // 주문금액 총합계
	ArrayList<Item> orderedItemList = new ArrayList<>();
	ArrayList<Integer> orderedItemCount = new ArrayList<>();;
/*
[주문아이디: 3] 20201010 사용자:  park - 주문금액:  5400 (포인트: 5점)
	 ( 3개) [F3124] 돌돌이자            	 1310원
	 ( 1개) [F3223] 스톱워치            	 1470원

 */
	@Override
	public void print() {
		print(true);
	}
	void print(boolean bDetail) {
		System.out.printf("[주문아이디:%2d] %s 사용자: %s ", id, date, user.userId);
		System.out.printf(" - 주문금액:%5d (포인트: %2d점)\n", total, point);
		if (!bDetail)
			return;
		for (int i = 0; i < orderedItemList.size(); i++) {
			System.out.printf("\t(%2d개)", orderedItemCount.get(i));
			orderedItemList.get(i).print();
		}
	}
	@Override
	public void read(Scanner scan2) {
		// TODO Auto-generated method stub
		id = scan2.nextInt();
		String userId = scan2.next();
		user = Store.findUser(userId);
		date = scan2.next();
		String itemId = scan2.next();
		Item item = null;
		while (!itemId.contentEquals("0")) {
			item = Store.findItem(itemId);
			if (item == null) {
				System.out.printf("ItemId Error: %s", itemId);
				continue;
			}
			orderedItemList.add(item);
			orderedItemCount.add(scan2.nextInt());
			itemId = scan2.next();
		}
		calcTotal();
		point = total / 1000;
		user.addOrder(this);
	}
	void calcTotal() {
		for (int i = 0; i < orderedItemList.size(); i++) {
			total += orderedItemList.get(i).getSubtotal(orderedItemCount.get(i));
		}
	}
	@Override
	public boolean matches(String kwd) {
		if (user.userId.equals(kwd))
			return true;
		if (date.contentEquals(kwd))
			return true;
		for (Item item: orderedItemList) 
			if (item.matches(kwd))
				return true;
		return false;
	}
}
