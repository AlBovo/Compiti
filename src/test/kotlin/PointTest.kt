import com.sun.source.tree.AssertTree
import org.junit.jupiter.api.*
import java.lang.AssertionError

internal class PointTest{
    @Test
    fun isOnTheOrigin(){
        val expected = true
        var point = Point()
        point.x = 0.0
        point.y = 0.0
        Assertions.assertEquals(expected, point.isOnTheOrigin())
    }

    @Test
    fun isNotOnTheOrigin(){
        val expected = false
        var point = Point()
        point.x = 3.1
        point.y = -42.0
        Assertions.assertEquals(expected, point.isOnTheOrigin())
    }

    @Test
    fun isOnTheAxisX(){
        val expected = true
        var point = Point()
        point.x = 0.0
        point.y = 2.1
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisX())
    }

    @Test
    fun isNotOnTheAxisX(){
        val expected = false
        var point = Point()
        point.x = 3.2
        point.y = 3.1
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisX())
    }

    @Test
    fun isOnTheAxisY(){
        val expected = true
        var point = Point()
        point.x = 4.3
        point.y = 0.0
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisY())
    }

    @Test
    fun isNotOnTheAxisY(){
        val expected = false
        var point = Point()
        point.x = 4.1
        point.y = -4.2
        Assertions.assertEquals(expected, point.findIfItsOnTheAxisY())
    }

    @Test
    fun valueOfXCannotBeZero(){
        var point = Point()
        point.x = 0.0
        point.y = -4.1
        assertThrows<IllegalArgumentException> {point.findTheQuadrant()}
    }

    @Test
    fun valueOfYCannotBeZero(){
        var point = Point()
        point.x = 3.0
        point.y = 0.0
        assertThrows<IllegalArgumentException> {point.findTheQuadrant()}
    }

    @Test
    fun canHaveFirstQuadrant() {
        val expected = 1
        var point = Point()
        point.x = 3.1
        point.y = 2.4
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }

    @Test
    fun canHaveSecondQuadrant(){
        val expected = 2
        var point = Point()
        point.x = -4.1
        point.y = 2.5
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }

    @Test
    fun canHaveThirdQuadrant(){
        val expected = 3
        var point = Point()
        point.x = -4.7
        point.y = -3.0
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }

    @Test
    fun canHaveFourthQuadrant(){
        val expected = 4
        var point = Point()
        point.x = 3.7
        point.y = -4.1
        Assertions.assertEquals(expected, point.findTheQuadrant())
    }

    @Test
    fun canCalculateDistance(){
        val expected = 0.0
        var point = Point()
        var pointSecond = Point()
        point.x = 0.0
        point.y = 0.0
        pointSecond.x = 0.0
        pointSecond.y = 0.0
        Assertions.assertEquals(expected, point.calculateDistance(pointSecond))
    }

    @Test
    fun canCalculateDistanceOfDifferentPoints() {
        val expected = 3.0
        var point = Point()
        var pointSecond = Point()
        point.x = 3.0
        point.y = 0.0
        pointSecond.x = 0.0
        pointSecond.y = 0.0
        Assertions.assertEquals(expected, point.calculateDistance(pointSecond))
    }
}