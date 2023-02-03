import kotlin.math.*
class Point{
    var x = 0.0
    var y = 0.0
    fun isOnTheOrigin(): Boolean {
        return x == 0.0 && y == 0.0
    }
    fun findIfItsOnTheAxisX(): Boolean {
        return x == 0.0
    }
    fun findIfItsOnTheAxisY(): Boolean {
        return y == 0.0
    }
    fun findTheQuadrant(): Int {
        require(x != 0.0) {
            "X cannot be on the axis (value : 0.0)"
        }
        require(y != 0.0) {
            "Y cannot be on the axis (value : 0.0)"
        }
        return if(x > 0.0 && y > 0.0) {
            1
        } else if(x < 0.0 && y > 0.0) {
            2
        } else if(x < 0.0 && y < 0.0) {
            3
        } else {
            4
        }
    }
    fun calculateDistance(point: Point): Double {
        return sqrt(((point.x - x)*(point.x - x)) + ((point.y-y)*(point.y-y)))
    }
}