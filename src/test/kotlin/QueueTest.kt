import org.junit.jupiter.api.*

class QueueTest{
    @Test
    fun theSizeOfTheQueueCannotBeNegative(){
        val size = -4
        assertThrows<IllegalArgumentException> { val queue = Queue(size) }
    }
    @Test
    fun push_theQueuePointerMustBeLessThanTheSize(){
        val queue = Queue(10)
        for(i in 0..9){
            queue.push(i)
        }
        assertThrows<IllegalStateException> { queue.push(10) }
    }
    @Test
    fun pop_theQueuePointerMustBeGreaterThanZero(){
        val queue = Queue(10)
        assertThrows<IllegalStateException> { queue.pop() }
    }
    @Test
    fun isEmpty_theFunctionIsCorrect(){
        val queue = Queue(10)
        val expected = true
        Assertions.assertEquals(queue.isEmpty(), expected)
    }
}