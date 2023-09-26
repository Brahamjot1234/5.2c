//importing libraries and renaming them
import RPi.GPIO as GPIO
import tkinter as tk

//setting GPIO pins 11,15,19 as output pins
GPIO.setmode(GPIO.BOARD)
GPIO.setup(11, GPIO.OUT)
GPIO.setup(15, GPIO.OUT)
GPIO.setup(19, GPIO.OUT)

//this function turns off the led
def all_of():
	GPIO.output(11,GPIO.LOW)
	GPIO.output(15,GPIO.LOW)
	GPIO.output(19,GPIO.LOW)


// it switches on and turns off the led connected to GPIO pin
def light_on(pin):
	if GPIO.input(pin) == GPIO.HIGH:
		GPIO.output(pin, GPIO.LOW)
	else:
		GPIO.output(pin,GPIO.HIGH)


window = tk.Tk() // creates the main GUI window
window.title("Control system")
//it sets dimensions and other background color
window.geometry("300x200")
window.configure(bg = "black")

chosen = tk.IntVar()


def close():// GUI window closes when exit is pressed
	GPIO.cleanup()
	window.destroy()

//light is turned on as per the selected colour
def light_no():
	if chosen.get() == 1:
		light_on(11)
	elif chosen.get() == 2:
		light_on(15)
	elif chosen.get() == 3:
		light_on(19)
		
	// creating radio button for each led color	
green = tk.Radiobutton(window, text = "GREEN ", variable = chosen, value = 1, command = light_no, bg = "green")
blue = tk.Radiobutton(window, text = "BLUE", variable = chosen, value = 2, command = light_no, bg = "blue")
red = tk.Radiobutton(window, text = "RED", variable = chosen, value = 3, command = light_no, bg = "red")
of = tk.Button(window, text = "OFF ALL", command = all_of, bg = "cyan")

esc = tk.Button(window, text ="EXIT", command = close, bg = "brown") // to exit the window

red.pack()
blue.pack()
green.pack()
of.pack()
esc.pack()


window.mainloop() // it starts the GUI loop

GPIO.cleanup()