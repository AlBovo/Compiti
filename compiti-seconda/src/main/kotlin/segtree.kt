import kotlin.math.*

class SegmentTree(array: Array<Int>){
    private var segment = Array<Int>(0){ 0 }
    private var size = 0
    private var sizeOfInitialArray = 0

    init{
        size = 1 shl ceil(log2(array.size.toFloat())).toInt()
        sizeOfInitialArray = array.size
        segment = Array(size * 2){ 0 }
        for(i in array.indices){
            segment[i + size] = array[i]
        }
        for(i in size-1 downTo 1){
            segment[i] = segment[i * 2]+segment[i * 2 + 1]
        }
    }

    private fun privateGetSum(node: Int, nodeRangeLeft: Int, nodeRangeRight: Int, queryRangeLeft: Int, queryRangeRight: Int): Int{ // the query range is [queryRangeLeft, queryRangeRight)
        if(queryRangeLeft >= nodeRangeRight || queryRangeRight <= nodeRangeLeft){
            return 0
        }
        if(nodeRangeLeft >= queryRangeLeft && nodeRangeRight <= queryRangeRight){
            return segment[node]
        }
        val left = privateGetSum(node * 2, nodeRangeLeft, (nodeRangeLeft + nodeRangeRight) / 2, queryRangeLeft, queryRangeRight)
        val right = privateGetSum(node * 2 + 1, (nodeRangeLeft + nodeRangeRight) / 2, nodeRangeRight, queryRangeLeft ,queryRangeRight)
        return left + right
    }
    private fun privateUpdate(nodePosition: Int, value: Int){
        var node = nodePosition + size
        segment[node] = value
        node /= 2
        while(node > 0){
            segment[node] = segment[node * 2] + segment[node * 2 + 1]
            node /= 2
        }
    }
    private fun check(){
        for(i in segment.indices){
            print(segment[i].toString() + " ")
        }
        println("")
    }
    fun getSum(queryLeft: Int, queryRight: Int): Int{
        require(queryLeft >= 0 && queryLeft < segment.size){
            "Left end is not correct, it must be greater than -1 and less than the size of the segment size"
        }
        require(queryRight >= 0 && queryRight <= segment.size){
            "Right end is not correct, it must be greater than -1 and less than the size of the segment size"
        }
        require(queryLeft <= queryRight){
            "The right end must be greater or equal to the left end"
        }
        return privateGetSum(1, 1, size, queryLeft, queryRight)
    }
    fun update(nodePosition: Int, value: Int){
        require(nodePosition in 0 until sizeOfInitialArray){
            "The node isn't in the segment tree"
        }
        privateUpdate(nodePosition, value)
        check()
    }
}

fun main(){
    val arr = arrayOf(2, 4, 2, 1, 3, 4, 5)
    val seg = SegmentTree(arr)
    print(seg.getSum(0, 4))
    //seg.update(3, 4)
}