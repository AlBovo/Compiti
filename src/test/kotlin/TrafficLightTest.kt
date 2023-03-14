import org.junit.jupiter.api.*
internal class TrafficLightTest{
    @Test
    fun typeCanBeOnlyItalian(){
        val traffic = TrafficLight(0)
        val expected = 0
        Assertions.assertEquals(expected, traffic.type)
    }
    @Test
    fun typeCanBeOnlyInternational(){
        val traffic = TrafficLight(1)
        val expected = 1
        Assertions.assertEquals(expected, traffic.type)
    }
    @Test
    fun cannotHaveNewStatusSameAsActual(){
        val traffic = TrafficLight(0)
        assertThrows<IllegalArgumentException> { traffic.changeStatus(0) }
    }
    @Test
    fun cannotHaveNegativeStatus(){
        val traffic = TrafficLight(0)
        assertThrows<IllegalArgumentException> { traffic.changeStatus(-1) }
    }
    @Test
    fun cannotHaveStatusGreaterThanTwo(){
        val traffic = TrafficLight(0)
        assertThrows<IllegalArgumentException> { traffic.changeStatus(3) }
    }
    @Test
    fun cannotHaveNewStatusOne(){
        val traffic = TrafficLight(0)
        assertThrows<IllegalArgumentException> { traffic.changeStatus(1) }
    }
    @Test
    fun test(){
        
    }
}