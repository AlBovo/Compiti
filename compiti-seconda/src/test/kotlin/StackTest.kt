import org.junit.jupiter.api.*
class StackTest{
    @Test
    fun sizeOfTheStackCannotBeNegative(){
        assertThrows<NegativeArraySizeException> { val stack = Stack(-4) }
    }
    @Test
    fun isEmptyIsCorrectAtTheStart(){
        val stack = Stack(10)
        val expected = true
        Assertions.assertEquals(expected, stack.isEmpty())
    }
    @Test
    fun isNotEmptyAfterFirstPush(){
        val stack = Stack(10)
        val expected = false
        stack.push(10)
        Assertions.assertEquals(expected, stack.isEmpty())
    }
    @Test
    fun pushFunctionIsCorrect(){
        val stack = Stack(10)
        stack.push(10)
        val expected = 10
        Assertions.assertEquals(expected, stack.pop())
    }
    @Test
    fun cannotPushMoreElementsThanTheSize(){
        val stack = Stack(10)
        for(i in 0..10){
            if(i == 10){
                assertThrows<IllegalStateException> { stack.push(i) }
            }
            else{
                stack.push(i)
            }
        }
    }
    @Test
    fun lastElementOfThePushIsEqualToThePopValue(){
        val stack = Stack(4)
        for(i in 0..3){
            stack.push(i)
        }
        val expected = 3
        Assertions.assertEquals(expected, stack.pop())
    }
    @Test
    fun cannotPopIfTheStackIsEmpty(){
        val stack = Stack(10)
        assertThrows<IllegalStateException> { stack.pop() }
    }
    @Test
    fun popFunctionIsCorrect(){
        val stack = Stack(10)
        val expected = 4
        stack.push(3)
        stack.push(-2)
        stack.push(4)
        Assertions.assertEquals(expected, stack.pop())
    }
}