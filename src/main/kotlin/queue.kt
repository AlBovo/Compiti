class Queue(private val size: Int){
    private var queue = Array<Int>(0){ 0 }
    private var queuePointer = 0
    init{
        require(size > 0){
            "The size of the queue must be positive"
        }
        queue = Array(size){ -1 }
    }
    fun isEmpty(): Boolean = queuePointer == 0
    fun push(value: Int){
        check(queuePointer < size){
            "Access out of bounds"
        }
        queue[queuePointer] = value
        queuePointer += 1
    }
    fun pop(): Int{
        check(queuePointer > 0){
            "The queue is empty"
        }
        val value = queue[0]
        for(i in 1 .. queuePointer){
            queue[i-1] = queue[i]
        }
        queuePointer -= 1
        return value
    }
}