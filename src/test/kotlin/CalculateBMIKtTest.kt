import org.junit.jupiter.api.*
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
internal class CalculateBMIKtTest{
    @Test
    fun heightCannotBeLowerOrEqualToZero(){
        assertThrows<IllegalArgumentException>{calculateBMI(16.0, 0.0)}
    }

    @Test
    fun weightCannotBeLowerOrEqualToZero(){
        assertThrows<IllegalArgumentException>{calculateBMI(0.0, 16.0)}
    }

    @Test
    fun cannotHaveBothLowerOrEqualToZeroValues(){
        assertThrows<IllegalArgumentException>{calculateBMI(0.0, 0.0)}
    }

    @Test
    fun canHaveUnderweight(){
        val expected = "Underweight"
        Assertions.assertEquals(expected, calculateBMI(47.36, 1.6))
    }

    @Test
    fun canHaveNormal_weight(){
        val expected = "Normal weight"
        Assertions.assertEquals(expected, calculateBMI(47.37, 1.6))
    }

    @Test
    fun canHaveNormal_weight1(){
        val expected = "Normal weight"
        Assertions.assertEquals(expected, calculateBMI(63.7, 1.6))
    }

    @Test
    fun canHaveOverweight(){
        val expected = "Overweight"
        Assertions.assertEquals(expected, calculateBMI(64.1, 1.6))
    }
}