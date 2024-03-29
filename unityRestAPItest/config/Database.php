<?php

Class Database {
    //DB Params
    private $host = 'localhost';
    private $db_name = 'unity';
    private $username = 'root';
    private $password = '';
    private $conn;
    //DB Connect
    public function connect(){
        $this->conn = null;

        try{
            $this->conn = NEW PDO('mysql:host=' . $this->host . ';dbname=' . $this->db_name, $this->username, $this->password);
            $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        }catch(PDOException $e){
            echo 'Connection error: ' . $e->getMessage();
        }
        return $this->conn;
    }
}

?>