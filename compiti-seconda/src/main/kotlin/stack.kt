class Stack(private val size: Int){
    private var stackPointer: Int = 0
    private val stack: Array<Int> = Array(size){0}
    init{
        require(size > 0){
            "The size of the stack cannot be negative"
        }
    }
    fun isEmpty() = stackPointer == 0
    fun push(value: Int){
        check(stackPointer < size){
            "Stackoverflow error with stack pointer = $stackPointer and size = $size"
        }
        stack[stackPointer] = value
        stackPointer++
    }
    fun pop(): Int{
        check(stackPointer > 0){
            "Cannot pop an empty stack"
        }
        stackPointer--
        return stack[stackPointer]
    }
}