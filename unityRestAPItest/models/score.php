<?php

Class Score{
    //DB Stuff
    private $conn;
    private $table = 'score';

    //Post Properties
    public $userID;
    public $scoreID;
    public $username;
    public $password;

    //Constructor with db
    public function __construct($db){
        $this->conn = $db;
    }

    //Create post
    public function create_score(){
        //Create query
        $query = 'INSERT INTO ' . $this->table . '
        SET
            userID = :userID,
            score = :score';

            //Preparing statement
            $stmt = $this->conn->prepare($query);

            //Clean data
            $this->userID =htmlspecialchars(strip_tags($this->userID));
            $this->score =htmlspecialchars(strip_tags($this->score));

            //Bind data
            $stmt->bindParam(':userID', $this->userID);
            $stmt->bindParam(':score', $this->score);

            //Executing query
            if($stmt->execute()){
                return true;
            }

            //Print error
            printf("Error: %s.\n", $stmt->error);
            return false;
    }

    public function read_score(){
        //Create query
        $query = 'SELECT * FROM ' . $this->table;
        //Preparing statement
        $stmt = $this->conn->prepare($query);
        //Executing query
        $stmt->execute();

        return $stmt;
    }
    
    //Get Single User
    public function read_single_score(){
        $query = 'SELECT * FROM '. $this->table . ' WHERE userID = ?';
        //Preparing statement
        $stmt = $this->conn->prepare($query);

        //Binding pageID
        $stmt->bindParam(1, $this->userID);

        //Executing query
        $stmt->execute();

        $row = $stmt->fetch(PDO::FETCH_ASSOC);

        //Setting properties
        $this->userID = $row['userID'];
        $this->scoreID = $row['scoreID'];
        $this->score = $row['score'];
    }

}

?>