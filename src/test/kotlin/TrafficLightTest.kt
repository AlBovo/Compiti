import org.junit.jupiter.api.*

internal class TrafficLightTest{
    @Test
    fun canMoveFromRedToGreenItalian(){
        val traffic = TrafficLight(0)
        val expected = 2
        traffic.changeStatusGreater()
        Assertions.assertEquals(expected, traffic.status)
    }
    @Test
    fun canMoveFromGreenToYellowItalian(){
        val trafficLight = TrafficLight(0)
        val expected = 1
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusLess()
        Assertions.assertEquals(expected, trafficLight.status)
    }
    @Test
    fun canMoveFromYellowToRedItalian(){
        val trafficLight = TrafficLight(0)
        val expected = 0
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusLess()
        trafficLight.changeStatusLess()
        Assertions.assertEquals(expected, trafficLight.status)
    }
    @Test
    fun cannotMoveToGreaterFromGreenItalian(){
        val trafficLight = TrafficLight(0)
        trafficLight.changeStatusGreater()
        assertThrows<IllegalStateException> { trafficLight.changeStatusGreater() }
    }
    @Test
    fun cannotMoveToLessFromRedItalian(){
        val trafficLight = TrafficLight(0)
        assertThrows<IllegalStateException> { trafficLight.changeStatusLess() }
    }
    @Test
    fun canMoveFromRedToYellowInternational(){
        val trafficLight = TrafficLight(1)
        val expected = 1
        trafficLight.changeStatusGreater()
        Assertions.assertEquals(expected, trafficLight.status)
    }
    @Test
    fun canMoveFromYellowToGreenInternational(){
        val trafficLight = TrafficLight(1)
        val expected = 2
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusGreater()
        Assertions.assertEquals(expected, trafficLight.status)
    }
    @Test
    fun canMoveFromGreenToYellowInternational(){
        val trafficLight = TrafficLight(1)
        val expected = 1
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusLess()
        Assertions.assertEquals(expected, trafficLight.status)
    }
    @Test
    fun canMoveFromYellowToRedInternational(){
        val trafficLight = TrafficLight(1)
        val expected = 0
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusLess()
        trafficLight.changeStatusLess()
        Assertions.assertEquals(expected, trafficLight.status)
    }
    @Test
    fun cannotMoveToLessFromRedInternational(){
        val trafficLight = TrafficLight(1)
        assertThrows<IllegalStateException> { trafficLight.changeStatusLess() }
    }
    @Test
    fun cannotMoveToGreaterFromGreenInternational(){
        val trafficLight = TrafficLight(1)
        trafficLight.changeStatusGreater()
        trafficLight.changeStatusGreater()
        assertThrows<IllegalStateException> { trafficLight.changeStatusGreater() }
    }
    @Test
    fun trafficLightTypeCanBeZero(){
        val trafficLight = TrafficLight(0)
        val expected = 0
        Assertions.assertEquals(trafficLight.type, expected)
    }
    @Test
    fun trafficLightTypeCannotBeNegative(){
        assertThrows<IllegalArgumentException> { val trafficLight = TrafficLight(-1) }
    }
    @Test
    fun trafficLightTypeCannotBeGreaterThanOne(){
        assertThrows<IllegalArgumentException> { val trafficLight = TrafficLight(2) }
    }
}