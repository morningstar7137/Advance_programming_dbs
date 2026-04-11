import socket                                     
import json                                      

def run_client():                                 
    host = '127.0.0.1'                            # Sets the server address to connect to
    port = 5001                                   # Sets the port number to connect to
    
    client_socket = socket.socket()               # Creates a new TCP socket object
    try:                                          # Starts a try block for exception handling
        client_socket.connect((host, port))       
        print("Successfully connected to the EasyDrive server!\n") 
        
        print("--- EasyDrive Registration ---")   
        name = input("Enter Name: ")              
        address = input("Enter Address: ")        
        pps = input("Enter PPS Number: ")        
        licence = input("Enter Driving License: ")
        
        customer = {                              # Creates a dictionary with customer data
            "Name": name,                         
            "Address": address,                   
            "PPS": pps,                           
            "License": licence                    
        }
        
        data = json.dumps(customer)               # Converts the dictionary to a JSON string
        client_socket.send(data.encode())         
        
        response = client_socket.recv(1024).decode() # Receives and decodes the response from server
        print("\nRegistration Successful!")       
        print("Your Registration Number: " + response) 
        
    except Exception as e:                        # Catches any exceptions during connection
        print("Error connecting to server: " + str(e)) 
        
    client_socket.close()                         

if __name__ == '__main__':                        
    run_client()                                  # Calls the run_client function to start
