import org.junit.jupiter.api.*
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
internal class CalculateSpeedKtTest{
    @Test
    fun cannotHaveZeroDistance(){
        assertThrows<IllegalArgumentException> {calculateSpeed(0.0, 10.0)}
    }

    @Test
    fun cannotHaveZeroTime(){
        assertThrows<IllegalArgumentException> {calculateSpeed(10.0, 0.0)}
    }

    @Test
    fun cannotHaveBothZeroValues(){
        assertThrows<IllegalArgumentException> {calculateSpeed(0.0, 0.0)}
    }

    @Test
    fun canHavePositiveDistance(){
        val expected = 10.0
        Assertions.assertEquals(expected, calculateSpeed(5.0, 2.0))
    }

    @Test
    fun canHavePositiveTime(){
        val expected = 10.0
        Assertions.assertEquals(expected, calculateSpeed(5.0, 2.0))
    }
}