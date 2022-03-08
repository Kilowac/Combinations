public class Queue<T>{
	/*
	 *Queue
	 */
	private boolean empty = true;
	private Node<T> end = new Node<T>(null);
	private Node<T> ptr;
	private Node<T> front;
	private T data;

	public Queue(){
		front = end;
	}

	public Queue(T data){
		front = end;
		enqueue(data);
	}

	public void enqueue(T data){
		if(data == null){
			return;
		}
		if(empty){
			front = new Node<T>(data);
			front.setRight(end);
			end.setLeft(front);
		} else {
			ptr = new Node<T>(data);
			end.getLeft().setRight(ptr);
			ptr.setRight(end);
			end.setLeft(ptr);
		}
		empty = false;
	}

	public T peek(){
		return front.getData();
	}

	public T dequeue(){
		if(empty){
			return null;
		}
		data = front.getData();
		front = front.getRight();
		if(front.getData() == null){
			front.setLeft(null);
			empty = true;
		}
		return data;
	}

	public boolean isEmpty(){
		return empty;
	}

}
