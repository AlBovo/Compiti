import org.junit.jupiter.api.*
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
internal class DataStationTest{
    @Test
    fun arrayCannotBeEmpty(){
        assertThrows<IllegalArgumentException> { DataStation(Array<Int>(0){0}) }
    }
    @Test
    fun maximumOfTheArrayIsCorrect(){
        val data = DataStation(arrayOf(0, 2, 3, -1, 4))
        val expected = 4
        Assertions.assertEquals(expected, data.max())
    }
    @Test
    fun maximumOfOnlyNegativeNumbersIsCorrect(){
        val data = DataStation(arrayOf(-4, -1, -2, -5))
        val expected = -1
        Assertions.assertEquals(expected, data.max())
    }
    @Test
    fun maximumOfOnlyPositiveNumbersIsCorrect(){
        val data = DataStation(arrayOf(4, 2, 3, 4, 1))
        val expected = 4
        Assertions.assertEquals(expected, data.max())
    }
    @Test
    fun maximumOfEqualNumbersIsCorrect(){
        val data = DataStation(Array(10){4})
        val expected = 4
        Assertions.assertEquals(expected, data.max())
    }
    @Test
    fun minimumOfTheArrayIsCorrect(){
        val data = DataStation(arrayOf(0, 2, 3, -1, 4))
        val expected = -1
        Assertions.assertEquals(expected, data.min())
    }
    @Test
    fun minimumOfOnlyNegativeNumbersIsCorrect(){
        val data = DataStation(arrayOf(-4, -1, -2, -5))
        val expected = -5
        Assertions.assertEquals(expected, data.min())
    }
    @Test
    fun minimumOfOnlyPositiveNumbersIsCorrect(){
        val data = DataStation(arrayOf(4, 2, 3, 4, 1))
        val expected = 1
        Assertions.assertEquals(expected, data.min())
    }
    @Test
    fun minimumOfEqualNumbersIsCorrect(){
        val data = DataStation(Array(10){4})
        val expected = 4
        Assertions.assertEquals(expected, data.min())
    }
    @Test
    fun mediaOfTheArrayIsCorrect(){
        val data = DataStation(arrayOf(0, 2, 3, -1, 4))
        val expected = (0.0+2.0+3.0-1.0+4.0)/5.0
        Assertions.assertEquals(expected, data.media())
    }
    @Test
    fun mediaOfOnlyNegativeNumbersIsCorrect(){
        val data = DataStation(arrayOf(-4, -1, -2, -5))
        val expected = (-4.0-1.0-2.0-5.0)/4.0
        Assertions.assertEquals(expected, data.media())
    }
    @Test
    fun mediaOfOnlyPositiveNumbersIsCorrect(){
        val data = DataStation(arrayOf(4, 2, 3, 4, 1))
        val expected = (4.0+2.0+3.0+4.0+1.0)/5.0
        Assertions.assertEquals(expected, data.media())
    }
    @Test
    fun mediaOfEqualNumbersIsCorrect(){
        val data = DataStation(Array(10){4})
        val expected = 4.0
        Assertions.assertEquals(expected, data.media())
    }
    @Test
    fun distinctIsCorrect(){
        val data = DataStation(arrayOf(4, 2, 1, 4, 3, 2))
        val expected = arrayOf(4, 2, 1, 3)
        Assertions.assertEquals(expected.contentEquals(data.distinct()), true)
    }
    @Test
    fun distinctIsCorrectEvenWithSameAbsoluteValue(){
        val data = DataStation(arrayOf(-4, 4, -2, 2, -3, 3))
        val expected = arrayOf(-4, 4, -2, 2, -3, 3)
        Assertions.assertEquals(expected.contentEquals(data.distinct()), true)
    }
    @Test
    fun distinctIsCorrectWithOnlyNegativeNumbers(){
        val data = DataStation(arrayOf(-4, -3, -2, -2, -3, -1))
        val expected = arrayOf(-4, -3, -2, -1)
        Assertions.assertEquals(expected.contentEquals(data.distinct()), true)
    }
    @Test
    fun distinctIsCorrectWithOnlyPositiveNumbers(){
        val data = DataStation(arrayOf(4, 3, 2, 2, 3, 1))
        val expected = arrayOf(4, 3, 2, 1)
        Assertions.assertEquals(expected.contentEquals(data.distinct()), true)
    }
    @Test
    fun getOverIsCorrect(){
        val data = DataStation(arrayOf(-4, -2, 4, 2, 3))
        val expected = arrayOf(4, 2, 3)
        Assertions.assertEquals(expected.contentEquals(data.getOver(0)), true)
    }
    @Test
    fun getOverIsCorrectWithOnlyNegativeNumbers(){
        val data = DataStation(arrayOf(-4, -11, -3, -2, -5))
        val expected = arrayOf(-4, -3, -2)
        Assertions.assertEquals(expected.contentEquals(data.getOver(-5)), true)
    }
    @Test
    fun getOverIsCorrectWithOnlyPositiveNumbers(){
        val data = DataStation(arrayOf(4, 11, 3, 2, 5))
        val expected = arrayOf(11)
        Assertions.assertEquals(expected.contentEquals(data.getOver(5)), true)
    }
    @Test
    fun getUnderIsCorrect(){
        val data = DataStation(arrayOf(-4, -2, 4, 2, 3))
        val expected = arrayOf(-4, -2)
        Assertions.assertEquals(expected.contentEquals(data.getUnder(0)), true)
    }
    @Test
    fun getUnderIsCorrectWithOnlyNegativeNumbers(){
        val data = DataStation(arrayOf(-4, -11, -3, -2, -5))
        val expected = arrayOf(-11)
        Assertions.assertEquals(expected.contentEquals(data.getUnder(-5)), true)
    }
    @Test
    fun getUnderIsCorrectWithOnlyPositiveNumbers(){
        val data = DataStation(arrayOf(4, 11, 3, 2, 5))
        val expected = arrayOf(4, 3, 2)
        Assertions.assertEquals(expected.contentEquals(data.getUnder(5)), true)
    }
}