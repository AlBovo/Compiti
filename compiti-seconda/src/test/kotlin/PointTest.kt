import org.junit.jupiter.api.*
internal class PointTest{
    @Test
    fun isOnTheOrigin(){
        val expected = true
        val point = Point(0.0, 0.0)
        Assertions.assertEquals(expected, point.isOnTheOrigin())
    }
    @Test
    fun isNotOnTheOrigin(){
        val expected = false
        val point = Point(3.1 , -42.0)
        Assertions.assertEquals(expected, point.isOnTheOrigin())
    }
    @Test
    fun isOnTheAxisX(){
        val expected = true
        val point = Point(0.0, 2.1)
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisX())
    }
    @Test
    fun isNotOnTheAxisX(){
        val expected = false
        val point = Point(3.2, 3.1)
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisX())
    }
    @Test
    fun isOnTheAxisY(){
        val expected = true
        val point = Point(4.3, 0.0)
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisY())
    }
    @Test
    fun isNotOnTheAxisY(){
        val expected = false
        val point = Point(4.1, -4.2)
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisY())
    }
    @Test
    fun valueOfXCannotBeZero(){
        val point = Point(0.0, -4.1)
        assertThrows<IllegalArgumentException> {point.findTheQuadrant()}
    }
    @Test
    fun valueOfYCannotBeZero(){
        val point = Point(3.0, 0.0)
        assertThrows<IllegalArgumentException> {point.findTheQuadrant()}
    }
    @Test
    fun canHaveFirstQuadrant() {
        val expected = 1
        val point = Point(3.1, 2.4)
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }
    @Test
    fun canHaveSecondQuadrant(){
        val expected = 2
        val point = Point(-4.1, 2.5)
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }
    @Test
    fun canHaveThirdQuadrant(){
        val expected = 3
        val point = Point(-4.7, -3.0)
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }
    @Test
    fun canHaveFourthQuadrant(){
        val expected = 4
        val point = Point(3.7, -4.1)
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }
    @Test
    fun canCalculateDistance(){
        val expected = 0.0
        val point = Point(0.0, 0.0)
        val pointSecond = Point(0.0, 0.0)
        Assertions.assertEquals(expected, point.calculateDistance(pointSecond))
    }
    @Test
    fun canCalculateDistanceOfDifferentPoints() {
        val expected = 3.0
        val point = Point(3.0, 0.0)
        val pointSecond = Point(0.0, 0.0)
        Assertions.assertEquals(expected, point.calculateDistance(pointSecond))
    }
}