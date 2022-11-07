package mid2021;
public interface Factory<T extends Manageable>  {
	T create();
}
