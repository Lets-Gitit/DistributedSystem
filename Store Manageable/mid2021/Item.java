package mid2021;

import java.util.Scanner;

public class Item implements Manageable, Comparable<Item> {
	String id;
	String name;
	private int price;
	// F3286 델리투명자 1140
	@Override
	public void read(Scanner scan) {
		id = scan.next();
		name = fillLength(scan.next(), 20);
		price = scan.nextInt();
	}
	// 유틸리티 함수
	static String fillLength(String origin, int len) {
		StringBuilder buil = new StringBuilder(origin);
		for (int i = origin.getBytes().length; i < len; i++)
			buil.append(' ');
		return buil.toString();
	}
	@Override
	public void print() {
		System.out.printf("[%s] %s\t",  id,  name);
		System.out.printf("%5d원\n", price);
	}
	@Override
	public boolean matches(String kwd) {
		if (name.contains(kwd))
		    return true;
		if (kwd.length() > 2 && id.contains(kwd))
		    return true;
		return false;
    }
	boolean matches(String[] kwdArr) {
		for (String kwd: kwdArr) {
			if (!matches(kwd))
				return false;
		}
		return true;
	}
	int getSubtotal(int count) {
		return price * count;  // 이벤트나 할인정책 등을 추후 반영 가능
	}
	@Override
	public int compareTo(Item other) {
		if(!name.equals((other.name)))
			return name.compareTo(other.name);
		if(!id.equals((other.id)))
			return id.compareTo(other.id);
		if(price > other.price) return 1;
		if(price < other.price) return -1;
		return 0;
	}
}
