import socket                                     # Imports the socket module for network connections
import json                                       # Imports the json module to format data

def run_client():                                 # Defines the main client function
    host = '127.0.0.1'                            # Sets the server address to connect to
    port = 5001                                   # Sets the port number to connect to
    
    client_socket = socket.socket()               # Creates a new TCP socket object
    try:                                          # Starts a try block for exception handling
        client_socket.connect((host, port))       # Connects to the server
        print("Successfully connected to the EasyDrive server!\n") # Prints success message
        
        print("--- EasyDrive Registration ---")   # Prints header
        name = input("Enter Name: ")              # Takes name input from user
        address = input("Enter Address: ")        # Takes address input from user
        pps = input("Enter PPS Number: ")         # Takes PPS input from user
        licence = input("Enter Driving License: ")# Takes license input from user
        
        customer = {                              # Creates a dictionary with customer data
            "Name": name,                         # Adds name to the dictionary
            "Address": address,                   # Adds address to the dictionary
            "PPS": pps,                           # Adds PPS to the dictionary
            "License": licence                    # Adds license to the dictionary
        }
        
        data = json.dumps(customer)               # Converts the dictionary to a JSON string
        client_socket.send(data.encode())         # Encodes and sends the JSON data to the server
        
        response = client_socket.recv(1024).decode() # Receives and decodes the response from server
        print("\nRegistration Successful!")       # Prints success message
        print("Your Registration Number: " + response) # Prints the received registration number
        
    except Exception as e:                        # Catches any exceptions during connection
        print("Error connecting to server: " + str(e)) # Prints the error message to the terminal
        
    client_socket.close()                         # Closes the socket connection

if __name__ == '__main__':                        # Checks if the script is run directly
    run_client()                                  # Calls the run_client function to start