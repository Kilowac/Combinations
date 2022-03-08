public class Node<T>{
	/*
	 * A general purpose node, made for AVL trees but just used for the queue
	 */
	private T data;
	public int weight = 0;
	public int lDepth = 0;
	public int rDepth = 0;
	private Node<T> parent = null;
	private Node<T> left = null;
	private Node<T> right = null;
	public Node(){
		data = null;
	}
	public Node(T data){
		this.data = data;
	}
	public Node(T data, Node<T> right){
		this.data = data;
		this.right = right;
	}
	public Node(T data, Node<T> right, Node<T> left){
		this.data = data;
		this.right = right;
		this.left = left;
	}

	public void setData(T data){ 
		this.data = data; 
	}

	public void setParent(Node<T> parent){ 
		this.parent = parent; 
	}

	public void setLeft(Node<T> left){ 
		this.left = left; 
	}

	public void setRight(Node<T> right){ 
		this.right = right; 
	}
	
	public T getData(){ 
		return data; 
	}
	
	public Node<T> getParent(){ 
		return parent; 
	}
	
	public Node<T> getLeft(){ 
		return left; 
	}
	
	public Node<T> getRight(){ 
		return right; 
	}

}
