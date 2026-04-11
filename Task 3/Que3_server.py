import socket                                     
import json                                       
import random                                    

def run_server():                                
    host = '127.0.0.1'                            # Sets the server address and port for the connection
    port = 5001                                   
    
    server_socket = socket.socket()               # Creates a new TCP socket 
    server_socket.bind((host, port))              # Binds the socket to the host and port
    server_socket.listen(1)                       # Listens for connections
    
    print("Server is waiting for client on port 5000...") 
    conn, address = server_socket.accept()     
    print("Connection established from: " + str(address)) 
    
    while True:                                   # Starts an infinite loop to receive data
        try:                                      
            data = conn.recv(1024).decode()      
            if not data:                         
                break                            
            
            print("Received customer data! Saving to database...") # Confirms data receipt
            customer = json.loads(data)          
            reg_num = "ED" + str(random.randint(1000, 9999)) 
            customer['RegNo'] = reg_num           # Adds the registration number to the dictionary
            
            with open("database.json", "a") as f: # Opens database.json in append mode to store data
                json.dump(customer, f)            
                f.write("\n")                     
                
            conn.send(reg_num.encode())           # Sends the unique registration number back to client
            print(f"Registration {reg_num} sent to client.\n") 
        except Exception as e:                    
            print("Error: " + str(e))             
            break                                
            
    conn.close()                                 

if __name__ == '__main__':                        # Checks if the script is run directly
    run_server()                                  
