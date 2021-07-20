#include <iostream>     // std::cout
#include <algorithm>    // std::random_shuffle
#include <vector>       // std::vector
#include <string>
#include <fstream>
#include <sstream>
#include <ostream>
#include <math.h>
#include <numeric>
#include <array>
#include <boost/random.hpp>
#include <time.h>

using namespace std;
using namespace boost;



void view(std::vector<int> v){for(size_t i=0; i<v.size(); i++){cout << v[i] << " ";}cout << endl;}
void view(std::vector<double> v){for(size_t i=0; i<v.size(); i++){cout << v[i] << " ";}cout << endl;}

void view(std::vector<std::vector<int> > vv){
  for(size_t i=0; i<vv.size(); i++){
    for(size_t j=0; j<vv[i].size(); j++){
      cout << vv[i][j] << " ";
    }
    cout << endl;
  }
}


/*
Update From 1.3 -->
Several Error have been killed for NegativeLearning

No FloorCeilingSetting
OLD:  CeilFloor(CurArrowParameta[d],1,100);
NEW:  CurArrowParameta[d] = CeilFloor(CurArrowParameta[d],1,100);

Reomoved the error for the exception


Update From 2.0 -> 2.1
Start the Trial from 0 (used to strat from 1)

2.3 Remove the error in [Season -1] is still left

2.4 
OLD  HunterMat[k][eF] = HunterMat[k][F] + norm_rand()// EnvErrorSD;// ;
New  HunterMat[k][eF] = HunterMat[k][F] + norm_rand()* EnvErrorSD;// ;


3.0 No bugs!

3.1  Remove Comment

3.2 Newly added non-individual laering option
3.2 Social Lering SD was set as 10
 
3.3 Finalize for publication

*/

// Gaussian function
double exp_distance(int X, int O){
	double  ans; double dist; double Xd; double Od;
	double sigma = 0.035;
	Xd = X + 0.0; Od = O + 0.0;
	dist = (-1) * pow ( ((Xd / 100.0) - (Od / 100.0)), 2);//^2
	ans = exp(dist / (2 * sigma));
	return ans;
}



// Fitness calculation function
int Calc_Fitness (double b1,int O1,int X1,double b2,int O2,int X2,double b3,int O3, int X3){
	int Fit;
	double t_bWs = 0.125;
	Fit= 1000 * (b1 * exp_distance(X1, O1) + b2 * exp_distance(X2, O2)+
				b3 * exp_distance(X3, O3)+ 0.125 * 1);
	return Fit;
}

// Truncating function for exceeding Min and Max
int CeilFloor (int v, int Minv, int  Maxv){
	if (v > Maxv){
		v = Maxv;
	} 
	if (v < Minv){
		v = Minv;
	}
	return v;
}

// Return -1 or 1, depending on the sign of number (if the number is 0 reuturn rondomly either -1  or 1)
int NegaPosiDeterminer (int Val, double Rnd){//Note that it requires random value to determine  the caes  that Val is 0, 
	int tempAns;
	if (Val > 1){tempAns = 1;} 
	else if (Val < 1) {tempAns = -1;}
	else {
		tempAns = -1;
		if (Rnd > 0.5){tempAns = 1;}
		}
	return tempAns;
}



int main (int argc, char const *argv[])
{
	
	//srand(time(0));
	srand(time(0));

	//Define rand()
	lagged_fibonacci1279 gen(static_cast<unsigned long>(time(0)));
	normal_distribution<> dst( 0.0, 1.0 );
	variate_generator<
		lagged_fibonacci1279, normal_distribution<>
		> norm_rand( gen, dst );
	
	minstd_rand n_gen(static_cast<unsigned long>(time(0)));
	uniform_real<> n_dst( 0, 1 );
	variate_generator<
		minstd_rand, uniform_real<>
		> uni_rand( n_gen, n_dst );



//****** paremeta setting do not change here
    
    
    int GroupNum =5000; // Population Size
	int MaxTrial = 35;
	int MaxDimention = 3;
	int MaxMember = MaxDimention;

	int MaxPoint = 1000;
 	int SocLearingInterval = 3;

    int NEGATIVE = -1;  int POSITIVE  =  1;
	
    int DIRECTIONAL= 1; // Memory Only Algorithm (initally neamed as directional)
    int MOVE = 2; // Fixed Stride Algorithm (initally neamed as move)
    int MIRROR = 3; // Variable Stride Algorithm (initally neamed as move)




    // defining fitness landscape
    
    double bWl = 0.275;
    double bWw = 0.25;
    double bWt = 0.35;
    double bWs = 0.125;

    int EnvErrorSD = 5;
    int SocLearnErrorM = 10;
    int SocLearnErrorSD = 10;

    // Should be same as Seasons
    // array<int, Season>
    array<int, 3> OL1 = {30, 36, 39};
    array<int, 3> OW1 = {63, 4, 17};
    array<int, 3> OT1 = {34, 57, 84};

    
    // since the landscape is unimodal those values are not used
    array<int, 3> OL2 = {99, 99 ,99};
    array<int, 3> OW2 = {88, 88, 88};
    array<int, 3> OT2 = {77, 77, 77};

    array<int, 3> InitialL = {52, 58, 61};
    array<int, 3> InitialW = {22, 73, 79};
    array<int, 3> InitialT = {75, 82, 38};
    array<int, 3> InitialS = {2, 3, 2};//shape is not used

	int SeasonNum = 3;
    int IndLearingOpp = 1;//0:No Ind Learing, 1: Do Ind Learning

    
    //*************************************************************
    //******************** SET THE PARAMETA HERE*******************
    // You can change below to test social learing algorithm, condition (asocial/negative/positive) and seasons
    

    int SocLearning = 0; // 0= asocial, 1 = social
    int SocLearningWay = MIRROR; //,DIRECTIONAL(memory only), MOVE(fixed stride), MIRROR(variable stride)
    int SocLearningCondition =1; //-1: Negative,  ; 1: Positive
    // If you want asocial leraing then you should choose SocLearing = 0, instead of setting here
    int Season = 3;--Season;//Start From 0 Thus Should be -1 (don't think just type Season 1 or 2 or 3)
    

    

    //*************************************************************
    //*************************************************************
   

	

    //calculate var
    double tM = 0.0;
    double tSM = 0.0;
    double tVar = 0.0;

	int CurPerformance;
	int CurErroedPeformance;
    int Fitness = 0;
    int erroredFitness = 0;

    vector <int> PosNegMemory (MaxDimention, 0); //Memory for Learning
    int tempNP;double tempUniRnd;// using to fill PosNegMemory

    vector <int> SocLearningDiffMemory (MaxDimention, 0);
    vector <int> SocModificationDirection (MaxDimention, 0);




    vector <int> CurArrowParameta (MaxDimention+2, 0); // Current Shape of Arrowhead //L, W, T, fitness errored Fitness
    int L = 0; int W = 1; int T = 2; int F = 3; int eF = 4;  //CurArrowParameta [L]
    int ChangeDimention =  0;
    int ChangeDistance = 5;


	vector < vector<int> > ArrowPerformance (MaxTrial,vector<int>(MaxMember,0));

	vector < vector<int> > HunterMat (MaxMember, vector<int>(MaxDimention+2,0));
	//nt L = 0; int W = 1; int T = 2; int F = 3; int eF = 4;

	vector <int> SumVect (MaxTrial, 0);
    vector <double> SqSumVect (MaxTrial, 0);


	vector <int> SocLearingOpp(MaxTrial, 0);


	SocLearingOpp[2] = 0;//To Avid Error


	if (SocLearning == 1){
	for (int ii=2; ii < MaxTrial; ii++){
		if ((ii % SocLearingInterval) == 2){
			SocLearingOpp[ii] = 1;
		}
	}
	}

	

	int ErrorCounter = 0;
	//Start Loop

	
	vector <double> tempV;
	double tempval;

	for (int CurGroup =0; CurGroup < GroupNum; CurGroup++){


		//cout<<CurGroup;

		//cout  << endl;  //++++++++++++++++//
		vector <int> CurArrowParameta (MaxDimention+2, 0);
		vector < vector<int> > ArrowPerformance (MaxTrial,vector<int>(MaxMember,0));
		vector < vector<int> > HunterMat (MaxMember, vector<int>(MaxDimention+2,0));
		vector <int> SocLearningDiffMemory (MaxDimention, 0);

		//cout << "A";
	//for (int CurGroup; CurGroup < 1; CurGroup++){
		for (int CurTrial = 0; CurTrial < MaxTrial; CurTrial++){

			//cout<<CurTrial<<",";			//cout << CurTrial;
			
			// Step1. Arrowhead Making

			//  In the first trial, the  participant use the defalt value
			if (CurTrial == 0){ // Here, have to use transmitted Arrowhead


				CurArrowParameta[L] = InitialL[Season];
				CurArrowParameta[W] = InitialW[Season];
				CurArrowParameta[T] = InitialT[Season];



				Fitness = Calc_Fitness(
					bWl, CurArrowParameta[L], OL1[Season],
					bWw, CurArrowParameta[W], OW1[Season],
				 	bWt, CurArrowParameta[T], OT1[Season]);

				erroredFitness = Fitness + norm_rand() * EnvErrorSD; 

				CurArrowParameta[F] = Fitness;
				CurArrowParameta[eF] = erroredFitness;


				SumVect[CurTrial] = SumVect[CurTrial] + Fitness;
                SqSumVect[CurTrial] = SqSumVect[CurTrial] + Fitness*Fitness;
				// Deciding Direction Randomly
				for (int m = 0; m < MaxDimention; m++){
					PosNegMemory [m] = -1;
					tempUniRnd = uni_rand();
					if (tempUniRnd > 0.5){PosNegMemory [m] = 1;}
				}

				/*
				
				cout<<endl<<endl<<CurTrial<<"****"<<endl;


				if (SocLearingOpp[CurTrial] == 1){
				view (HunterMat);

				}
				view (CurArrowParameta);

				cout<<"****"<<endl<<endl;

				*/
				


			//  From the sedond trial, the participant modified arrowhead 
			} else {

				
				
				if (SocLearingOpp[CurTrial] == 1){
					 ErrorCounter = 0;
					for (int k = 0; k<MaxDimention; k++){//each Hunter (i.e. Hunter = Dimention)

						for (int d = 0; d < MaxDimention; d++){// Copy the parameta of individual
						HunterMat[k][d]= CurArrowParameta[d];
						}

						tempUniRnd = uni_rand();
						SocModificationDirection[k]= -1;
						if (tempUniRnd > 0.5){SocModificationDirection[k]= 1;}
						HunterMat[k][k] = HunterMat[k][k] + (norm_rand()* SocLearnErrorSD + SocLearnErrorM)* SocModificationDirection[k];
						HunterMat[k][k] = CeilFloor(HunterMat[k][k],1,100);
						//HunterMat[k][F] = Calc_Fitness(bWl, HunterMat[L], OL1[Season],bWw, HunterMat[W], OW1[Season],bWt, HunterMat[T], OT1[Season]);
						HunterMat[k][F]  = Calc_Fitness(bWl, HunterMat[k][L], OL1[Season],bWw, HunterMat[k][W], OW1[Season],bWt, HunterMat[k][T], OT1[Season]);
						HunterMat[k][F] = CeilFloor(HunterMat[k][F] ,1,1000);
						HunterMat[k][eF] = HunterMat[k][F] + norm_rand()* EnvErrorSD;// ;
						HunterMat[k][eF] = CeilFloor(HunterMat[k][F] ,1,1000);
						//scout << CurTrial << "," << k  << endl;
						//view(CurArrowParameta);
						//view(HunterMat[k]);

						SocLearningDiffMemory[k] = HunterMat[k][k] - CurArrowParameta[k];//Save Difference between the arrowmaker and other hunters

						if (SocLearningCondition == NEGATIVE){
							int resetIF = 0;
							//SocLearningDiffMemory[k] = SocLearningDiffMemory[k]*(-1);
							//cout<<k<<endl;
							//cout << "*" << SocLearningDiffMemory[k] <<"*"<<endl;
							//cout << "*" << SocLearningDiffMemory[k]*(-1)<<"*"<<endl;
							SocLearningDiffMemory[k]=SocLearningDiffMemory[k]*(-1);
							//SocLearningDiffMemory[k] = 1*2;
							if (HunterMat[k][eF] > CurArrowParameta[eF]){resetIF = 1;}
							if (HunterMat[k][F] >= CurArrowParameta[F]){resetIF = 1;}
							if (resetIF == 1){k--;}
							
							
						} else if (SocLearningCondition == POSITIVE){
							int resetIF = 0;
							if (HunterMat[k][eF] < CurArrowParameta[eF]){resetIF = 1;}
							if (HunterMat[k][F] <= CurArrowParameta[F]){resetIF = 1;}
							if (resetIF == 1){k--;}
							//SocLearningDiffMemory[k] = SocLearningDiffMemory[k]*(1);
						}
						 ErrorCounter ++;
						 if (ErrorCounter>10000){
						 	
						 	
						 	k++;
						 	//cout<<endl<<CurTrial<<","<<"k="<<k<<",ErrorCounnter="<<ErrorCounter<<","<<Fitness<<",Par="<<CurArrowParameta[k]<<",Hunt="<<HunterMat[k][k]<<endl;
						 	SocLearningDiffMemory[k] = 0;

						 	ErrorCounter=0;
						 }
					}// end k


					if(SocLearningWay == DIRECTIONAL){
						for (int d=0; d<MaxDimention; d++){
							if (d == ChangeDimention){// Searching for previously changed dimention
								if(NegaPosiDeterminer(SocLearningDiffMemory[d],uni_rand()) != PosNegMemory[d]){
									PosNegMemory[d] = NegaPosiDeterminer(0, uni_rand());//coin flip model:randomly allocate if social info and privious individual info contradicts
								}
							} else {PosNegMemory[d] = NegaPosiDeterminer(SocLearningDiffMemory[d],uni_rand());}
						}

					} else if(SocLearningWay == MOVE){
					//	if(SocLearningWay == MOVE){
						for (int d=0; d<MaxDimention; d++){
							//CurArrowParameta[1] = CurArrowParameta[1] + ChangeDistance *  (-1);
							if (SocLearningDiffMemory[d] != 0){
								CurArrowParameta[d] = CurArrowParameta[d] + 3 * NegaPosiDeterminer(SocLearningDiffMemory[d],uni_rand());
								CurArrowParameta[d] = CeilFloor(CurArrowParameta[d],1,100);
							//CurArrowParameta[d] = CurArrowParameta[d] + ChangeDistance *  NegaPosiDeterminer(SocLearningDiffMemory[d],uni_rand());
							}
						}

					} else if(SocLearningWay == MIRROR){
						for (int d=0; d < MaxDimention; d++){
							//if (SocLearningDiffMemory[d] != 0){
								CurArrowParameta[d] = CurArrowParameta[d] + SocLearningDiffMemory[d];
								CurArrowParameta[d] = CeilFloor(CurArrowParameta[d],1,100);
							//}
						}
					}// end SocLearingWay



				}// end SocLearing Oppt
				
				/////INDIVIDUAL LEARNING


				/*
				cout<<endl<<endl<<CurTrial<<"****"<<endl;
				if (SocLearingOpp[CurTrial] == 1){
				view (HunterMat);
				cout<<"!!";
				view (CurArrowParameta);}
				*/


				if(IndLearingOpp == 1) {


					tempUniRnd = uni_rand() * 3;
					ChangeDimention = L;
					if (tempUniRnd > 1) { ChangeDimention = W; }
					if (tempUniRnd > 2) { ChangeDimention = T; }

					CurArrowParameta[ChangeDimention] = CurArrowParameta[ChangeDimention] + PosNegMemory[ChangeDimention] * ChangeDistance;
					CurArrowParameta[ChangeDimention] = CeilFloor(CurArrowParameta[ChangeDimention], 1, 100);


					Fitness = Calc_Fitness(
						bWl, CurArrowParameta[L], OL1[Season],
						bWw, CurArrowParameta[W], OW1[Season],
						bWt, CurArrowParameta[T], OT1[Season]);

					Fitness = CeilFloor(Fitness, 1, 1000);

					erroredFitness = Fitness + (norm_rand() * EnvErrorSD);
					erroredFitness = CeilFloor(erroredFitness, 1, 1000);

					SumVect[CurTrial] = SumVect[CurTrial] + Fitness;
                    SqSumVect[CurTrial] = SqSumVect[CurTrial] + Fitness*Fitness;
					//Step3. Learning and Update

					// Note that only parameta is updated is that CurArrowParameta[ChangeDimention], CurArrowParameta[F] is not yet updated.

					if ((erroredFitness - CurArrowParameta[F]) > 0) {
						PosNegMemory[ChangeDimention] = PosNegMemory[ChangeDimention];
					}
					else {
						PosNegMemory[ChangeDimention] = PosNegMemory[ChangeDimention] * (-1);
					}

					CurArrowParameta[F] = Fitness;
					CurArrowParameta[eF] = erroredFitness;



				} //End if IndlearingOpp



			} //end InD



			// Step2. 

			//view (CurArrowParameta);
			//cout<<Fitness<<","; //++++++++++++++++//

		}//trial
	}//



	

	cout<<endl;
	
	//view(SumVect);
    //view(SqSumVect);
	

	for (int gg = 0; gg < MaxTrial; gg ++){
		cout<< "," <<(SumVect.at(gg))*1.00/GroupNum;
	
	}
    /*
    cout<<endl;
    for (int kk = 0; kk < MaxTrial; kk ++){
        
        tM =SumVect.at(kk)*1.00/GroupNum;
        tSM = SqSumVect.at(kk)*1.00/GroupNum;
        tVar = tSM - tM*tM;
        cout<< "," <<tVar;
    }
    */
    cout<<endl;
    for (int kk = 0; kk < MaxTrial; kk ++){
        
        tM =SumVect.at(kk)*1.00/GroupNum;
        tSM = SqSumVect.at(kk)*1.00/GroupNum;
        tVar = tSM - tM*tM;
        cout<< "," << sqrt(tVar)/sqrt(GroupNum);
    }
	 cout<<endl;

	return 0;

 }





