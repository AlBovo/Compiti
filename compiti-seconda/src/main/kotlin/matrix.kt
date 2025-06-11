class Matrix(private val length: Int, private val height: Int){
    private var matrix = Array(0){0}
    init{
        require(length > 0){ "The length of the matrix must be positive" }
        require(height > 0){ "The height of the matrix must be positive" }
        matrix = Array(length * height){0}
    }
    fun get(row: Int, column: Int): Int{
        require(row in 0 until length){
            "The row cannot be lower than zero or greater than the length of the matrix"
        }
        require(column in 0 until height){
            "The column cannot be lower than zero or greater than the height of the matrix"
        }
        return matrix[row * height + column]
    }
    fun set(row: Int, column: Int, newValue: Int){
        require(row in 0 until length){
            "The row cannot be lower than zero or greater than the length of the matrix"
        }
        require(column in 0 until height){
            "The column cannot be lower than zero or greater than the height of the matrix"
        }
        matrix[row * height + column] = newValue
    }
}